const D = document;
//TODO Skill Container Script

const skillNameInput = D.querySelector(".skill-enter-information-form .name input"),
    skillLevelSelect = D.querySelector(".skill-enter-information-form .level select"),
    skillLevelSelectOptions = skillLevelSelect.querySelectorAll("option"),
    skillFirstTextInForm = D.querySelector(".skill-enter-information-form .first-text span"),
    skillErorrTextName = D.querySelector(".skill-erorr-text-name"),
    skillErorrTextLevel = D.querySelector(".skill-erorr-text-level"),
    skillFirstText = D.querySelector(".skill-first-text-lable"),
    skillFirstTextValue = D.querySelector(".skill-first-text-value");

//console.log(skillErorrTextName)

const skillInputFirstTextFValue = skillFirstTextValue.textContent;

var checkTemperryDeleteForDeletedAllSkill = true; //* for that time all skill is deleted and we wanted first text in form come back

let selectedOptionFirstValue;

var skillDB = []; //* skill database 
var sortedSkillIds = []; //* skill database for priority

const nameErorrText = "یک متن برای مهارت خود وارد کنید .",
    levelErorrText = "یک سطح برای مهارت خود انتخاب کنید",
    sameRecoardErorrText = "این مهارت قبلا ثبت شده .";

$(document).ready(function () {
    //TODO defult seting
    //$("#skill-enter-information").slideUp();

    //TODO
    function fullBothSideAfterChange() {

        skillErorrTextName.innerText = "";
        skillErorrTextLevel.innerText = "";

        if (skillDB.length == 0) {
            $(".skill-enter-information-skills-box").html("");
            $("#skill-information-skills-box").html("");
            $("#skill-information-skills-box").addClass("d-none");
            skillFirstTextInForm.classList.remove("d-none");
            $(".skill-enter-information-skills-box").addClass("d-none");
            skillFirstText.classList.replace("greenColor2", "text-dark");
            skillFirstTextValue.classList.remove("d-none");
        }

        if (!skillDB.length == 0) {
            $("#skill-information-skills-box").html(" ");
            $("#skill-information-skills-box").removeClass("d-none");
            $(".skill-enter-information-skills-box").html(" ");
            skillFirstTextInForm.classList.add("d-none");
            $(".skill-enter-information-skills-box").removeClass("d-none");
            skillFirstText.classList.replace("text-dark", "greenColor2");
            skillFirstTextValue.classList.add("d-none");

            let informationElemet = "", EnterInformationElement = "";

            for (let i = 0; i < skillDB.length; i++) {
                EnterInformationElement += ` <li class="rounded-2 greenBack2 text-white d-flex align-items-center justify-content-center p-1 m-1 sortable-item" data-skillPri-id="${skillDB[i].id}"><span class="mx-2">${skillDB[i].name}</span>  |  <span class="mx-2">${skillDB[i].value}</span>   <i class="ri-close-fill fs-5 text-white itemSkill" data-skill-id="${skillDB[i].id}"></i></li> `;
                skillDB[i].deleted = false;

                informationElemet += ` <li class="skill-view rounded-2 greenBack2 text-white d-flex align-items-center justify-content-center p-1 m-1"><span class="mx-2">${skillDB[i].name}</span>  |  <span class="mx-2">${skillDB[i].value}</span></li> `;
            }


            $(".skill-enter-information-skills-box").html(EnterInformationElement);
            $("#skill-information-skills-box").html(informationElemet);

            $(".itemSkill").click(function (e) {
                this.parentElement.remove();
                let deleteId = $(this).attr("data-skill-id");
                for (let i = 0; i < skillDB.length; i++) {
                    if (skillDB[i].id == deleteId) {
                        skillDB[i].deleted = true;
                    }
                }

                checkTemperryDeleteForDeletedAllSkill = true; //* for that time all skill is deleted and we wanted first text in form come back

                for (let io = 0; io < skillDB.length; io++) { //* for that time all skill is deleted and we wanted first text in form come back
                    if (skillDB[io].deleted !== true) {
                        checkTemperryDeleteForDeletedAllSkill = false;
                        break;
                    }
                }

                if (checkTemperryDeleteForDeletedAllSkill) { //* for that time all skill is deleted and we wanted first text in form come back
                    skillFirstTextInForm.classList.remove("d-none");
                    $(".skill-enter-information-skills-box").addClass("d-none");
                }
            });

            $(".skill-view").click(function (e) {
                $("#skill-information").slideToggle("slow");
                $("#skill-enter-information").slideToggle("slow");

                $("#skill-btn-change").addClass("d-none");

                fullBothSideAfterChange();

                sortedSkillIds = [];

                skillNameInput.focus();
            });

        }


    }

    function emptyInputSkill() {
        skillNameInput.value = "";
        skillLevelSelectOptions.forEach(option => {
            option.selected = false;
            if (option.value === "choose") {
                skillLevelSelect.style.fontWeight = "200";
                option.selected = true;
            };
        });
    }

    function getAllSkill() {
        $.ajax({
            type: "GET",
            url: "https://localhost:7120/api/skills",
            contentType: "application/json; charset=utf-8",
            success: (data) => {
                jQuery.each(data, (index, itemData) => {
                    skillDB.push({ id: itemData.id, name: itemData.name, value: itemData.skillValue, priority: itemData.priority, deleted: false });
                });
                fullBothSideAfterChange();
            }
        })
    };

    function getMax(arr, prop) {
        var max;
        for (var i = 0; i < arr.length; i++) {
            if (max == null || parseInt(arr[i][prop]) > parseInt(max[prop]))
                max = arr[i];
        }
        return max;
    }

    //! change btn for go in form
    $("#skill-btn-change").click(function () {

        $("#skill-information").slideToggle("slow");
        $("#skill-enter-information").slideToggle("slow");

        $("#skill-btn-change").addClass("d-none");

        fullBothSideAfterChange();

        sortedSkillIds = [];

        skillNameInput.focus();

    });

    //! back btn
    $("#skill-enter-information-back-btn").click(function () {
        $("#skill-information").slideToggle("slow");
        $("#skill-enter-information").slideToggle("slow");

        $("#skill-btn-change").removeClass("d-none");

        emptyInputSkill();

        sortedSkillIds = [];
    });

    getAllSkill();

    $("#sortable-list").sortable({
        update: function (event, ui) {

            sortedSkillIds = [];

            $(".sortable-item").each(function () {
                sortedSkillIds.push($(this).data("skillpri-id"));
            });

        }
    });

    //! for change text style in select in form after chosse enather option
    skillLevelSelect.addEventListener("change", function () { skillLevelSelect.style.fontWeight = "400" });

    //! save btn
    $("#skill-enter-information-save-btn").click(function (e) {
        let ids = [];
        let skillDBLength = skillDB.length;
        for (let i = 0; i < skillDBLength; i++) {
            if (skillDB[i].deleted) {
                ids.push(skillDB[i].id);
            }
        }

        skillDB = skillDB.filter(item => item.deleted !== true);

        $.ajax({
            type: "DELETE",
            url: "https://localhost:7120/api/skills",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(ids),
            success: function (data) {
                if (data.success) {
                    fullBothSideAfterChange();
                    emptyInputSkill();
                }
            }
        });

        if (sortedSkillIds.length != 0) {
            $.ajax({
                type: 'PUT',
                url: 'https://localhost:7120/api/skills',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(sortedSkillIds),
                success: function (data) {
                    if (data.success) {
                        skillDB = [];
                        getAllSkill();
                    }
                }
            });
        }

        $("#skill-information").slideToggle("slow");
        $("#skill-enter-information").slideToggle("slow");

        $("#skill-btn-change").removeClass("d-none");

    });

    //! add btn
    $("#skill-add-icon").click(function (e) {

        selectedOptionFirstValue = skillLevelSelect.querySelector("option:checked");

        let name = skillNameInput.value;
        let level = skillLevelSelect.querySelector("option:checked").value;
        let priority = 0;

        var hasRecoardInDb = false;

        const testNameValueForHasedInDb1 = name.trim();
        const testNameValueForHasedInDb2 = testNameValueForHasedInDb1.replace(/\s+/g, ' ');
        const testNameValueForHasedInDb3 = testNameValueForHasedInDb2.toLowerCase();

        for (let h = 0; h < skillDB.length; h++) { //* Check to see if we don't have an object with this name in the database
            var testForSameRecord = skillDB[h].name.toLowerCase();
            if (testForSameRecord === testNameValueForHasedInDb3) {
                hasRecoardInDb = true;
            }
        }

        function showErorrTag() {
            $(skillErorrTextLevel).removeClass("d-none");
            $(skillErorrTextName).removeClass("d-none");
        }

        if (skillLevelSelect && selectedOptionFirstValue.value !== "choose" && level !== "" && level !== null && !hasRecoardInDb) {

            skillErorrTextName.innerText = "";
            skillErorrTextLevel.innerText = "";

            skillFirstTextInForm.classList.add("d-none");
            $(".skill-enter-information-skills-box").removeClass("d-none");

            if (skillDB.length != 0) {
                priorty = getMax(skillDB, "priority").priority;
                priorty += 1;
            } else {
                priorty = 1;
            }

            $.ajax({
                type: "POST",
                url: "https://localhost:7120/api/skills",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ Name: name, SkillValue: level, IsActive: true }),
                success: function (data) {
                    if (data.success) {
                        skillDB.push({ id: data.id, name: name, value: level, priority: priorty, deleted: false });
                        fullBothSideAfterChange();
                        emptyInputSkill();
                    }
                },
                error: function () {
                    $(".skill-erorr-text-level").html("خطا در ارسال درخواست.");
                    success = false;
                }
            });
        }

        else if ((name === "" || name === null) && (!skillLevelSelect || selectedOptionFirstValue.value === "choose")) {
            skillErorrTextName.innerText = `${nameErorrText}`;
            skillErorrTextLevel.innerText = `${levelErorrText}`;
            showErorrTag();
        } else if (hasRecoardInDb) {
            skillErorrTextName.innerText = `${sameRecoardErorrText}`;
            if (!skillLevelSelect || selectedOptionFirstValue.value === "choose") {
                skillErorrTextLevel.innerText = `${levelErorrText}`;
            } else {
                skillErorrTextLevel.innerText = "";
            }
            showErorrTag();
        } else if (name === "" || name === null) {
            skillErorrTextName.innerText = `${nameErorrText}`;
            skillErorrTextLevel.innerText = "";
            showErorrTag();
        } else if (!skillLevelSelect || selectedOptionFirstValue.value === "choose") {
            if (name === "" || name === null) {
                skillErorrTextName.innerText = `${nameErorrText}`;
            } else {
                skillErorrTextName.innerText = "";
            }
            skillErorrTextLevel.innerText = `${levelErorrText}`;
            showErorrTag();
        } else if ((name === "" || name === null) && hasRecoardInDb) {
            skillErorrTextName.innerHtml = `<span>${nameErorrText}</span><br><span>${sameRecoardErorrText}</span> `;
            skillErorrTextLevel.innerText = "";
            showErorrTag();
        }
        skillNameInput.focus();
    });

    $(".go-back-skill").click(function () {

        $("#skill-information").slideToggle("slow");
        $("#skill-enter-information").slideToggle("slow");

        fullBothSideAfterChange();

        sortedSkillIds = [];

        skillNameInput.focus();
    });

});