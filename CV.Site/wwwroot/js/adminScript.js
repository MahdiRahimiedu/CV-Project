//Functions of the whole system

var validatorDB = [];// To store validation information temporarily

const emptyErorrText = "فیلد را پر کنید .",
      choosErorrText = "یک گزینرو انتخاب کنید .",
      sameErorrText = "این رکورد قبلا ثبت شده .";

function FormValidator() {

    for (let i = 0; i < validatorDB.length; i++) {
        $(validatorDB[i].erorrTag).text("");

        if (validatorDB[i].checkEmpty) { 
            if (validatorDB[i].inputValue === "" || validatorDB[i].inputValue === null) $(validatorDB[i].erorrTag).text(emptyErorrText);
        }
        if (!validatorDB[i].checkEqual === false) {
            if (validatorDB[i].inputValue == validatorDB[i].checkEqual) $(validatorDB[i].erorrTag).text(choosErorrText);
        }
        if (validatorDB[i].chackHasBefor) $(validatorDB[i].erorrTag).text(sameErorrText);
    }
    validatorDB = [];
}

function getMax(arr, prop) {
    var max;
    for (var i = 0; i < arr.length; i++) {
        if (max == null || parseInt(arr[i][prop]) > parseInt(max[prop]))
            max = arr[i];
    }
    return max;
}


const D = document;


//TODO Skill Container Script ===============================================

const skillNameInput = D.querySelector(".skill-enter-information-form .name input"),
    skillLevelSelect = D.querySelector(".skill-enter-information-form .level select"),
    skillLevelSelectOptions = skillLevelSelect.querySelectorAll("option"),
    skillFirstTextInForm = D.querySelector(".skill-enter-information-form .first-text span"),
    skillFirstText = D.querySelector(".skill-first-text-lable"),
    skillFirstTextValue = D.querySelector(".skill-first-text-value");

const skillInputFirstTextFValue = skillFirstTextValue.textContent;

var checkTemperryDeleteForDeletedAllSkill = true; //* for that time all skill is deleted and we wanted first text in form come back

let selectedOptionFirstValue;

var skillDB = []; //* skill database 
var sortedSkillIds = []; //* skill database for priority

//TODO Favorite Container Script ===============================================

const favoriteNameInput = D.querySelector(".favorite-enter-information-form .name input"),
    favoriteDetailInput = D.querySelector(".favorite-enter-information-form .detail input"),
    favoriteFirstTextInForm = D.querySelector(".favorite-enter-information-form .first-text span"),
    favoriteFirstText = D.querySelector(".favorite-first-text-lable"),
    favoriteFirstTextValue = D.querySelector(".favorite-first-text-value");

const favoriteInputFirstTextFValue = favoriteFirstTextValue.textContent;

var checkTemperryDeleteForDeletedAllFavorite = true; //* for that time all favorite is deleted and we wanted first text in form come back

var favoriteDB = []; //* favorite database
//TODO Servic Container Script ===============================================

const servicNameInput = D.querySelector(".servic-enter-information-form .name input"),
    servicIconInput = D.querySelector(".servic-enter-information-form .icon input"),
    servicFirstTextInForm = D.querySelector(".servic-enter-information-form .first-text span"),
    servicFirstText = D.querySelector(".servic-first-text-lable"),
    servicFirstTextValue = D.querySelector(".servic-first-text-value");

const servicInputFirstTextFValue = servicFirstTextValue.textContent;

var checkTemperryDeleteForDeletedAllServic = true; //* for that time all servic is deleted and we wanted first text in form come back

var servicDB = []; //* servic database
var sortedServicIds = []; //* servic database for priority


//TODO Doing Container Script ===============================================

const doingNameInput = D.querySelector(".doing-enter-information-form .name input"),
    doingLocationInput = D.querySelector(".doing-enter-information-form .location input"),
    doingDetailInput = D.querySelector(".doing-enter-information-form .detail input"),
    doingFirstTextInForm = D.querySelector(".doing-enter-information-form .first-text span"),
    doingFirstText = D.querySelector(".doing-first-text-lable"),
    doingFirstTextValue = D.querySelector(".doing-first-text-value");

const doingInputFirstTextFValue = doingFirstTextValue.textContent;

var checkTemperryDeleteForDeletedAllDoing = true; //* for that time all doing is deleted and we wanted first text in form come back

var doingDB = []; //* doing database

//TODO Social Net Work Container Script ===============================================

const socialNameInput = D.querySelector(".social-enter-information-form .name input"),
    socialAddressInput = D.querySelector(".social-enter-information-form .address input"),
    socialIconInput = D.querySelector(".social-enter-information-form .icon input"),
    socialFirstTextInForm = D.querySelector(".social-enter-information-form .first-text span"),
    socialFirstText = D.querySelector(".social-first-text-lable"),
    socialFirstTextValue = D.querySelector(".social-first-text-value");

const socialInputFirstTextFValue = socialFirstTextValue.textContent;

var checkTemperryDeleteForDeletedAllDoing = true; //* for that time all social is deleted and we wanted first text in form come back

var socialDB = []; //* social database

//TODO Project Container Script ===============================================

const projectNameInput = D.querySelector(".project-enter-information-form .name input"),
    projectApplicantInput = D.querySelector(".project-enter-information-form .applicant input"),
    projectDateInput = D.querySelector(".project-enter-information-form .date input"),
    projectImgInput = D.querySelector(".project-enter-information-form .img input"),
    projectFirstTextInForm = D.querySelector(".project-enter-information-form .first-text span"),
    projectFirstText = D.querySelector(".project-first-text-lable"),
    projectFirstTextValue = D.querySelector(".project-first-text-value");

 const projectInputFirstTextFValue = projectFirstTextValue.textContent;

 var checkTemperryDeleteForDeletedAllDoing = true; //* for that time all project is deleted and we wanted first text in form come back

var projectDB = []; //* project database

//TODO Education Container Script ===============================================


const educationNameInput = D.querySelector(".education-enter-information-form .name input"),
    educationLocationInput = D.querySelector(".education-enter-information-form .location input"),
    educationDateInput = D.querySelector(".education-enter-information-form .date input"),
    educationImgInput = D.querySelector(".education-enter-information-form .img input"),
    educationFirstText = D.querySelector(".education-first-text-lable"),
    educationFirstTextValue = D.querySelector(".education-first-text-value"),
    educationSortableBox = D.querySelector("#education-sortable-box");

const educationInputFirstTextFValue = educationFirstTextValue.textContent;

var educationDB = []; //* education database
var sortedEducationIds = []; //* education database for priority

$(document).ready(function () {
    
    // {} Skill Container Script -----------------------------------------------
    function fullBothSideAfterChangeSkill() {

        $(".skill-erorr-text-name").text("");
        $(".skill-erorr-text-level").text("");

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
                EnterInformationElement += ` <li class="rounded-2 greenBack2 text-white d-flex align-items-center justify-content-center p-1 m-1 sortable-item" style="cursor: grab;" data-skillPri-id="${skillDB[i].id}"><span class="mx-2">${skillDB[i].name}</span>  |  <span class="mx-2">${skillDB[i].value}</span>   <i class="ri-close-fill fs-5 text-white itemSkill" style="cursor: pointer;" data-skill-id="${skillDB[i].id}"></i></li> `;
                skillDB[i].deleted = false;

                informationElemet += ` <li class="skill-view rounded-2 greenBack2 text-white d-flex align-items-center justify-content-center p-1 m-1" style="flex : 1;cursor: pointer;"><span class="mx-2">${skillDB[i].name}</span>  |  <span class="mx-2">${skillDB[i].value}</span></li> `;
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

                checkTemperryDeleteForDeletedAllSkill = true; 

                for (let io = 0; io < skillDB.length; io++) {
                    if (skillDB[io].deleted !== true) {
                        checkTemperryDeleteForDeletedAllSkill = false;
                        break;
                    }
                }

                if (checkTemperryDeleteForDeletedAllSkill) { 
                    skillFirstTextInForm.classList.remove("d-none");
                    $(".skill-enter-information-skills-box").addClass("d-none");
                }
            });

            $(".skill-view").click(function (e) {
                D.querySelector(".skill-Container-Box").scrollIntoView({ behavior: 'smooth' });
                $("#skill-information").slideToggle("slow");
                $("#skill-enter-information").slideToggle("slow");

                $("#skill-btn-change").addClass("d-none");

                fullBothSideAfterChangeSkill();

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
                fullBothSideAfterChangeSkill();
            }
        })
    };

    //! change btn for go in form
    $("#skill-btn-change").click(function () {
        D.querySelector(".skill-Container-Box").scrollIntoView({ behavior: 'smooth' });
        $("#skill-information").slideToggle("slow");
        $("#skill-enter-information").slideToggle("slow");

        $("#skill-btn-change").addClass("d-none");

        fullBothSideAfterChangeSkill();

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

    $("#sortable-list-skill").sortable({
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
                    fullBothSideAfterChangeSkill();
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

        if (skillLevelSelect && selectedOptionFirstValue.value !== "choose" && name !== "" && name !== null && !hasRecoardInDb) {

            $(".skill-erorr-text-name").text("");
            $(".skill-erorr-text-level").text("");

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
                        fullBothSideAfterChangeSkill();
                        emptyInputSkill();
                    }
                },
                error: function () {
                    $(".skill-erorr-text-name").html("خطا در ارسال درخواست.");
                    success = false;
                }
            });
        }

        validatorDB.push({ inputValue: name.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: hasRecoardInDb, erorrTag: ".skill-erorr-text-name" });
        validatorDB.push({ inputValue: selectedOptionFirstValue.value, checkEmpty: false, checkEqual: "choose", chackHasBefor: false, erorrTag: ".skill-erorr-text-level" });

        FormValidator();

        skillNameInput.focus();
    });

    $(".go-back-skill").click(function () {
        D.querySelector(".skill-Container-Box").scrollIntoView({ behavior: 'smooth' });
        $("#skill-information").slideToggle("slow");
        $("#skill-enter-information").slideToggle("slow");

        fullBothSideAfterChangeSkill();

        $("#skill-btn-change").addClass("d-none");

        sortedSkillIds = [];

        skillNameInput.focus();
    });

    // {} Favorite Container Script  -----------------------------------------------

    function fullBothSideAfterChangeFavorite() {

        $(".favorite-erorr-text-name").text("");
/*        $(".favorite-erorr-text-level").text("");*/

        if (favoriteDB.length == 0) {
            $(".favorite-enter-information-favorites-box").html("");
            $("#favorite-information-favorites-box").html("");
            $("#favorite-information-favorites-box").addClass("d-none");
            favoriteFirstTextInForm.classList.remove("d-none");
            $(".favorite-enter-information-favorites-box").addClass("d-none");
            favoriteFirstText.classList.replace("greenColor2", "text-dark");
            favoriteFirstTextValue.classList.remove("d-none");
        }

        if (!favoriteDB.length == 0) {
            $("#favorite-information-favorites-box").html(" ");
            $("#favorite-information-favorites-box").removeClass("d-none");
            $(".favorite-enter-information-favorites-box").html(" ");
            favoriteFirstTextInForm.classList.add("d-none");
            $(".favorite-enter-information-favorites-box").removeClass("d-none");
            favoriteFirstText.classList.replace("text-dark", "greenColor2");
            favoriteFirstTextValue.classList.add("d-none");

            let informationElemet = "", EnterInformationElement = "";

            for (let i = 0; i < favoriteDB.length; i++) {
                EnterInformationElement += ` <li class="rounded-2 greenBack2 text-white ps-4 d-flex align-items-center justify-content-start p-1 m-1 position-relative"><span class="mx-2">${favoriteDB[i].name}</span>  :  <span class="mx-2">${favoriteDB[i].detail}</span>   <i class="ri-close-fill fs-5 text-white itemFavorite position-absolute top-0 start-0 ps-2" style="padding-top:.4rem;" data-favorite-id="${favoriteDB[i].id}"></i></li> `;
                favoriteDB[i].deleted = false;

                informationElemet += ` <li class="favorite-view greenBack2 rounded-2 text-white d-flex align-items-center justify-content-start p-1 m-1" style="flex : 1;cursor: pointer;"><span class="mx-2">${favoriteDB[i].name}</span>  :  <span class="mx-2">${favoriteDB[i].detail}</span></li> `;
            }

            $(".favorite-enter-information-favorites-box").html(EnterInformationElement);
            $("#favorite-information-favorites-box").html(informationElemet);

            $(".itemFavorite").click(function (e) {
                this.parentElement.remove();
                let deleteId = $(this).attr("data-favorite-id");
                for (let i = 0; i < favoriteDB.length; i++) {
                    if (favoriteDB[i].id == deleteId) {
                        favoriteDB[i].deleted = true;
                    }
                }

                checkTemperryDeleteForDeletedAllFavorite = true;

                for (let io = 0; io < favoriteDB.length; io++) {
                    if (favoriteDB[io].deleted !== true) {
                        checkTemperryDeleteForDeletedAllFavorite = false;
                        break;
                    }
                }

                if (checkTemperryDeleteForDeletedAllFavorite) {
                    favoriteFirstTextInForm.classList.remove("d-none");
                    $(".favorite-enter-information-skills-box").addClass("d-none");
                }
            });

            $(".favorite-view").click(function (e) {
                D.querySelector(".favorite-Container-Box").scrollIntoView({ behavior: 'smooth' });
                $("#favorite-information").slideToggle("slow");
                $("#favorite-enter-information").slideToggle("slow");

                $("#favorite-btn-change").addClass("d-none");

                fullBothSideAfterChangeFavorite();

                favoriteNameInput.focus();

            });


        }


    }

    function emptyInputFavorite() {
        favoriteNameInput.value = "";
        favoriteDetailInput.value = "";
    }

    function getAllFavorite() {
        $.ajax({
            type: "GET",
            url: "https://localhost:7120/api/favorites",
            contentType: "application/json; charset=utf-8",
            success: (data) => {
                jQuery.each(data, (index, itemData) => {
                    favoriteDB.push({ id: itemData.id, name: itemData.name, detail: itemData.detail, deleted: false });
                });
                fullBothSideAfterChangeFavorite();
            }
        })
    };

    //! change btn for go in form
    $("#favorite-btn-change").click(function () {
        D.querySelector(".favorite-Container-Box").scrollIntoView({ behavior: 'smooth' });
        $("#favorite-information").slideToggle("slow");
        $("#favorite-enter-information").slideToggle("slow");

        $("#favorite-btn-change").addClass("d-none");

        fullBothSideAfterChangeFavorite();

        favoriteNameInput.focus();

    });

    //! back btn
    $("#favorite-enter-information-back-btn").click(function () {
        $("#favorite-information").slideToggle("slow");
        $("#favorite-enter-information").slideToggle("slow");

        $("#favorite-btn-change").removeClass("d-none");

        emptyInputFavorite();

    });

    getAllFavorite();

    //! save btn
    $("#favorite-enter-information-save-btn").click(function (e) {
        let ids = [];
        let favoriteDBLength = favoriteDB.length;
        for (let i = 0; i < favoriteDBLength; i++) {
            if (favoriteDB[i].deleted) {
                ids.push(favoriteDB[i].id);
            }
        }

        favoriteDB = favoriteDB.filter(item => item.deleted !== true);

        $.ajax({
            type: "DELETE",
            url: "https://localhost:7120/api/favorites",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(ids),
            success: function (data) {
                if (data.success) {
                    fullBothSideAfterChangeFavorite();
                    emptyInputFavorite();
                }
            }
        });


        $("#favorite-information").slideToggle("slow");
        $("#favorite-enter-information").slideToggle("slow");

        $("#favorite-btn-change").removeClass("d-none");

    });

    //! add btn
    $("#favorite-add-icon").click(function (e) {

        let name = favoriteNameInput.value;
        let detailP = favoriteDetailInput.value;
        let priority = 0;

        var hasRecoardInDb = false;

        const testNameValueForHasedInDb1 = name.trim();
        const testNameValueForHasedInDb2 = testNameValueForHasedInDb1.replace(/\s+/g, ' ');
        const testNameValueForHasedInDb3 = testNameValueForHasedInDb2.toLowerCase();

        for (let h = 0; h < favoriteDB.length; h++) { //* Check to see if we don't have an object with this name in the database
            var testForSameRecord = favoriteDB[h].name.toLowerCase();
            if (testForSameRecord === testNameValueForHasedInDb3) {
                hasRecoardInDb = true;
            }
        }

        if (name !== "" && name !== null && !hasRecoardInDb) {

            $(".favorite-erorr-text-name").text("");

            favoriteFirstTextInForm.classList.add("d-none");
            $(".favorite-enter-information-favorites-box").removeClass("d-none");

            $.ajax({
                type: "POST",
                url: "https://localhost:7120/api/favorites",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ Name: name, Detail: detailP }),
                success: function (data) {
                    if (data.success) {
                        favoriteDB.push({ id: data.id, name: name, detail: detailP, deleted: false });
                        fullBothSideAfterChangeFavorite();
                        emptyInputFavorite();
                    }
                },
                error: function () {
                    $(".favorite-erorr-text-name").html("خطا در ارسال درخواست.");
                    success = false;
                }
            });
        }

        validatorDB.push({ inputValue: name.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: hasRecoardInDb, erorrTag: ".favorite-erorr-text-name" });

        FormValidator();

        favoriteNameInput.focus();

    });

    $(".go-back-favorite").click(function () {
        D.querySelector(".favorite-Container-Box").scrollIntoView({ behavior: 'smooth' });
        $("#favorite-information").slideToggle("slow");
        $("#favorite-enter-information").slideToggle("slow");

        fullBothSideAfterChangeFavorite();

        $("#favorite-btn-change").addClass("d-none");

        favoriteNameInput.focus();
    });

    // {} Servic Container Script  -----------------------------------------------
    function fullBothSideAfterChangeServic() {

        $(".servic-erorr-text-name").text("");

        if (servicDB.length == 0) {
            $(".servic-enter-information-servics-box").html("");
            $("#servic-information-servics-box").html("");
            $("#servic-information-servics-box").addClass("d-none");
            servicFirstTextInForm.classList.remove("d-none");
            $(".servic-enter-information-servics-box").addClass("d-none");
            servicFirstText.classList.replace("greenColor2", "text-dark");
            servicFirstTextValue.classList.remove("d-none");
        }

        if (!servicDB.length == 0) {
            $("#servic-information-servics-box").html(" ");
            $("#servic-information-servics-box").removeClass("d-none");
            $(".servic-enter-information-servics-box").html(" ");
            servicFirstTextInForm.classList.add("d-none");
            $(".servic-enter-information-servics-box").removeClass("d-none");
            servicFirstText.classList.replace("text-dark", "greenColor2");
            servicFirstTextValue.classList.add("d-none");

            let informationElemet = "", EnterInformationElement = "";

            for (let i = 0; i < servicDB.length; i++) {
                EnterInformationElement += ` <li class="rounded-2 greenBack2 text-white d-flex align-items-center justify-content-center p-1 m-1 sortable-item-servic" style="cursor: grab;" data-servicPri-id="${servicDB[i].id}"><span class="mx-2">${servicDB[i].name}</span>  |  <i class="mx-2 ri-${servicDB[i].icon}-fill "></i>   <i class="ri-close-fill fs-5 text-white itemServic" style="cursor: pointer" data-servic-id="${servicDB[i].id}"></i></li> `;
                servicDB[i].deleted = false;

                informationElemet += ` <li class="servic-view rounded-2 greenBack2 text-white d-flex align-items-center justify-content-center p-1 m-1" style="flex : 1;cursor: pointer;"><span class="mx-2">${servicDB[i].name}</span>  |  <i class="mx-2 ${servicDB[i].icon}"></i></li> `;
            }

            $(".servic-enter-information-servics-box").html(EnterInformationElement);
            $("#servic-information-servics-box").html(informationElemet);

            $(".itemServic").click(function (e) {
                this.parentElement.remove();
                let deleteId = $(this).attr("data-servic-id");
                for (let i = 0; i < servicDB.length; i++) {
                    if (servicDB[i].id == deleteId) {
                        servicDB[i].deleted = true;
                    }
                }

                checkTemperryDeleteForDeletedAllServic = true;

                for (let io = 0; io < servicDB.length; io++) {
                    if (servicDB[io].deleted !== true) {
                        checkTemperryDeleteForDeletedAllServic = false;
                        break;
                    }
                }

                if (checkTemperryDeleteForDeletedAllServic) {
                    servicFirstTextInForm.classList.remove("d-none");
                    $(".servic-enter-information-servics-box").addClass("d-none");
                }
            });

            $(".servic-view").click(function (e) {
                D.querySelector(".servic-Container-Box").scrollIntoView({ behavior: 'smooth' });

                $("#servic-information").slideToggle("slow");
                $("#servic-enter-information").slideToggle("slow");

                $("#servic-btn-change").addClass("d-none");

                fullBothSideAfterChangeServic();

                sortedServicIds = [];

                servicNameInput.focus();
            });

        }


    }

    function emptyInputServic() {
        servicNameInput.value = "";
        servicIconInput.value = "";
    }

    function getAllServic() {
        $.ajax({
            type: "GET",
            url: "https://localhost:7120/api/services",
            contentType: "application/json; charset=utf-8",
            success: (data) => {
                jQuery.each(data, (index, itemData) => {
                    servicDB.push({ id: itemData.id, name: itemData.name, icon: itemData.icon, priority: itemData.priority, deleted: false });
                });
                fullBothSideAfterChangeServic();
            }
        })
    };

    //! change btn for go in form
    $("#servic-btn-change").click(function () {
        D.querySelector(".servic-Container-Box").scrollIntoView({ behavior: 'smooth' });
        $("#servic-information").slideToggle("slow");
        $("#servic-enter-information").slideToggle("slow");

        $("#servic-btn-change").addClass("d-none");

        fullBothSideAfterChangeServic();

        sortedServicIds = [];

        servicNameInput.focus();

    });

    //! back btn
    $("#servic-enter-information-back-btn").click(function () {
        $("#servic-information").slideToggle("slow");
        $("#servic-enter-information").slideToggle("slow");

        $("#servic-btn-change").removeClass("d-none");

        emptyInputServic();

        sortedServicIds = [];
    });

    getAllServic();

    $("#sortable-list-servic").sortable({
        update: function (event, ui) {

            sortedServicIds = [];

            $(".sortable-item-servic").each(function () {
                sortedServicIds.push($(this).data("servicpri-id"));
            });

        }
    });

    //! save btn
    $("#servic-enter-information-save-btn").click(function (e) {
        let ids = [];
        let servicDBLength = servicDB.length;
        for (let i = 0; i < servicDBLength; i++) {
            if (servicDB[i].deleted) {
                ids.push(servicDB[i].id);
            }
        }

        servicDB = servicDB.filter(item => item.deleted !== true);

        $.ajax({
            type: "DELETE",
            url: "https://localhost:7120/api/services",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(ids),
            success: function (data) {
                if (data.success) {
                    fullBothSideAfterChangeServic();
                    emptyInputServic();
                }
            }
        });

        if (sortedServicIds.length != 0) {
            $.ajax({
                type: 'PUT',
                url: 'https://localhost:7120/api/services',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(sortedServicIds),
                success: function (data) {
                    if (data.success) {
                        servicDB = [];
                        getAllServic();
                    }
                }
            });
        }

        $("#servic-information").slideToggle("slow");
        $("#servic-enter-information").slideToggle("slow");

        $("#servic-btn-change").removeClass("d-none");

    });

    //! add btn
    $("#servic-add-icon").click(function (e) {

        let name = servicNameInput.value;
        let iconP = servicIconInput.value;
        let priority = 0;

        var hasRecoardInDb = false;

        const testNameValueForHasedInDb1 = name.trim();
        const testNameValueForHasedInDb2 = testNameValueForHasedInDb1.replace(/\s+/g, ' ');
        const testNameValueForHasedInDb3 = testNameValueForHasedInDb2.toLowerCase();

        for (let h = 0; h < servicDB.length; h++) { //* Check to see if we don't have an object with this name in the database
            var testForSameRecord = servicDB[h].name.toLowerCase();
            if (testForSameRecord === testNameValueForHasedInDb3) {
                hasRecoardInDb = true;
            }
        }

        if (name !== "" && name !== null && !hasRecoardInDb) {

            $(".servic-erorr-text-name").text("");

            servicFirstTextInForm.classList.add("d-none");
            $(".servic-enter-information-servics-box").removeClass("d-none");

            if (servicDB.length != 0) {
                priorty = getMax(servicDB, "priority").priority;
                priorty += 1;
            } else {
                priorty = 1;
            }

            $.ajax({
                type: "POST",
                url: "https://localhost:7120/api/services",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ Name: name, Icon: iconP }),
                success: function (data) {
                    if (data.success) {
                        servicDB.push({ id: data.id, name: name, icon: iconP, priority: priorty, deleted: false });
                        fullBothSideAfterChangeServic();
                        emptyInputServic();
                    }
                },
                error: function () {
                    $(".servic-erorr-text-name").html("خطا در ارسال درخواست.");
                    success = false;
                }
            });
        }

        validatorDB.push({ inputValue: name.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: hasRecoardInDb, erorrTag: ".servic-erorr-text-name" });

        FormValidator();

        servicNameInput.focus();
    });

    $(".go-back-servic").click(function () {
        D.querySelector(".servic-Container-Box").scrollIntoView({ behavior: 'smooth' });

        $("#servic-information").slideToggle("slow");
        $("#servic-enter-information").slideToggle("slow");

        fullBothSideAfterChangeServic();

        $("#servic-btn-change").addClass("d-none");

        sortedServicIds = [];

        servicNameInput.focus();
    });

    // {} Doing Container Script  -----------------------------------------------

    function fullBothSideAfterChangeDoing() {
        $(".doing-erorr-text-name").text("");
        $(".doing-erorr-text-detail").text("");

        if (doingDB.length == 0) {
            $(".doing-enter-information-doings-box").html("");
            $("#doing-information-doings-box").html("");
            $("#doing-information-doings-box").addClass("d-none");
            doingFirstTextInForm.classList.remove("d-none");
            $(".doing-enter-information-doings-box").addClass("d-none");
            doingFirstText.classList.replace("greenColor2", "text-dark");
            doingFirstTextValue.classList.remove("d-none");
        }

        if (!doingDB.length == 0) {
            $("#doing-information-doings-box").html(" ");
            $("#doing-information-doings-box").removeClass("d-none");
            $(".doing-enter-information-doings-box").html(" ");
            doingFirstTextInForm.classList.add("d-none");
            $(".doing-enter-information-doings-box").removeClass("d-none");
            doingFirstText.classList.replace("text-dark", "greenColor2");
            doingFirstTextValue.classList.add("d-none");

            let informationElemet = "", EnterInformationElement = "";

            for (let i = 0; i < doingDB.length; i++) {
                EnterInformationElement += ` <li class="rounded-2 greenBack2 text-white ps-4 d-flex align-items-center justify-content-start p-1 m-1 position-relative"><span class="mx-2">${doingDB[i].name}</span>  :  <span class="mx-2">${doingDB[i].location}</span> | <span class="mx-2">${doingDB[i].detail}</span>   <i class="ri-close-fill fs-5 text-white itemDoing position-absolute top-0 start-0 ps-2" style="padding-top:.4rem;" data-doing-id="${doingDB[i].id}"></i></li> `;
                doingDB[i].deleted = false;

                informationElemet += ` <li class="doing-view greenBack2 rounded-2 text-white d-flex align-items-center justify-content-start p-1 m-1" style="flex : 1;cursor: pointer;"><span class="mx-2">${doingDB[i].name}</span>  :  <span class="mx-2">${doingDB[i].location}</span> | <span class="mx-2">${doingDB[i].detail}</span></li> `;
            }

            $(".doing-enter-information-doings-box").html(EnterInformationElement);
            $("#doing-information-doings-box").html(informationElemet);

            $(".itemDoing").click(function (e) {
                this.parentElement.remove();
                let deleteId = $(this).attr("data-doing-id");
                for (let i = 0; i < doingDB.length; i++) {
                    if (doingDB[i].id == deleteId) {
                        doingDB[i].deleted = true;
                    }
                }

                checkTemperryDeleteForDeletedAllDoing = true;

                for (let io = 0; io < doingDB.length; io++) {
                    if (doingDB[io].deleted !== true) {
                        checkTemperryDeleteForDeletedAllDoing = false;
                        break;
                    }
                }

                if (checkTemperryDeleteForDeletedAllDoing) {
                    doingFirstTextInForm.classList.remove("d-none");
                    $(".doing-enter-information-doings-box").addClass("d-none");
                }
            });

            $(".doing-view").click(function (e) {
                D.querySelector(".doing-Container-Box").scrollIntoView({ behavior: 'smooth' });
                $("#doing-information").slideToggle("slow");
                $("#doing-enter-information").slideToggle("slow");

                $("#doing-btn-change").addClass("d-none");

                fullBothSideAfterChangeDoing();

                doingNameInput.focus();

            });


        }


    }

    function emptyInputDoing() {
        doingNameInput.value = "";
        doingLocationInput.value = "";
        doingDetailInput.value = "";
    }

    function getAllDoing() {
        $.ajax({
            type: "GET",
            url: "https://localhost:7120/api/doings",
            contentType: "application/json; charset=utf-8",
            success: (data) => {
                jQuery.each(data, (index, itemData) => {
                    doingDB.push({ id: itemData.id, name: itemData.title, location: itemData.location, detail: itemData.detail, deleted: false });
                });
                fullBothSideAfterChangeDoing();
            }
        })
    };

    //! change btn for go in form
    $("#doing-btn-change").click(function () {
        D.querySelector(".doing-Container-Box").scrollIntoView({ behavior: 'smooth' });
        $("#doing-information").slideToggle("slow");
        $("#doing-enter-information").slideToggle("slow");

        $("#doing-btn-change").addClass("d-none");

        fullBothSideAfterChangeDoing();

        doingNameInput.focus();

    });

    //! back btn
    $("#doing-enter-information-back-btn").click(function () {
        $("#doing-information").slideToggle("slow");
        $("#doing-enter-information").slideToggle("slow");

        $("#doing-btn-change").removeClass("d-none");

        emptyInputDoing();

    });

    getAllDoing();

    //! save btn
    $("#doing-enter-information-save-btn").click(function (e) {
        let ids = [];
        let doingDBLength = doingDB.length;
        for (let i = 0; i < doingDBLength; i++) {
            if (doingDB[i].deleted) {
                ids.push(doingDB[i].id);
            }
        }

        doingDB = doingDB.filter(item => item.deleted !== true);

        $.ajax({
            type: "DELETE",
            url: "https://localhost:7120/api/doings",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(ids),
            success: function (data) {
                if (data.success) {
                    fullBothSideAfterChangeDoing();
                    emptyInputDoing();
                }
            }
        });


        $("#doing-information").slideToggle("slow");
        $("#doing-enter-information").slideToggle("slow");

        $("#doing-btn-change").removeClass("d-none");

    });

    //! add btn
    $("#doing-add-icon").click(function (e) {

        let name = doingNameInput.value;
        let locationP = doingLocationInput.value;
        let detailP = doingDetailInput.value;
        let priority = 0;

        var hasRecoardInDb = false;

        const testNameValueForHasedInDb1 = name.trim();
        const testNameValueForHasedInDb2 = testNameValueForHasedInDb1.replace(/\s+/g, ' ');
        const testNameValueForHasedInDb3 = testNameValueForHasedInDb2.toLowerCase();

        for (let h = 0; h < doingDB.length; h++) { //* Check to see if we don't have an object with this name in the database
            var testForSameRecord = doingDB[h].name.toLowerCase();
            if (testForSameRecord === testNameValueForHasedInDb3) {
                hasRecoardInDb = true;
            }
        }

        if (name !== "" && name !== null && !hasRecoardInDb) {

            $(".doing-erorr-text-name").text("");
            $(".doing-erorr-detail-name").text("");

            doingFirstTextInForm.classList.add("d-none");
            $(".doing-enter-information-doings-box").removeClass("d-none");

            $.ajax({
                type: "POST",
                url: "https://localhost:7120/api/doings",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ Title: name, Location: locationP , Detail: detailP }),
                success: function (data) {
                    if (data.success) {
                        doingDB.push({ id: data.id, name: name, detail: detailP, location: locationP, deleted: false });
                        fullBothSideAfterChangeDoing();
                        emptyInputDoing();
                    }
                },
                error: function () {
                    $(".doing-erorr-text-name").html("خطا در ارسال درخواست.");
                    success = false;
                }
            });
        }

        validatorDB.push({ inputValue: name.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: hasRecoardInDb, erorrTag: ".doing-erorr-text-name" });
        validatorDB.push({ inputValue: detailP.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: false, erorrTag: ".doing-erorr-text-detail" });

        FormValidator();

        doingNameInput.focus();

    });

    $(".go-back-doing").click(function () {
        D.querySelector(".doing-Container-Box").scrollIntoView({ behavior: 'smooth' });
        $("#doing-information").slideToggle("slow");
        $("#doing-enter-information").slideToggle("slow");

        fullBothSideAfterChangeDoing();

        $("#doing-btn-change").addClass("d-none");

        doingNameInput.focus();
    });

    // {} Social Net Work Container Script  -----------------------------------------------

    function fullBothSideAfterChangeSocial() {
        $(".social-erorr-text-name").text("");
        $(".social-erorr-text-address").text("");
        $(".social-erorr-text-icon").text("");

        if (socialDB.length == 0) {
            $(".social-enter-information-socials-box").html("");
            $("#social-information-socials-box").html("");
            $("#social-information-socials-box").addClass("d-none");
            socialFirstTextInForm.classList.remove("d-none");
            $(".social-enter-information-socials-box").addClass("d-none");
            socialFirstText.classList.replace("greenColor2", "text-dark");
            socialFirstTextValue.classList.remove("d-none");
        }

        if (!socialDB.length == 0) {
            $("#social-information-socials-box").html(" ");
            $("#social-information-socials-box").removeClass("d-none");
            $(".social-enter-information-socials-box").html(" ");
            socialFirstTextInForm.classList.add("d-none");
            $(".social-enter-information-socials-box").removeClass("d-none");
            socialFirstText.classList.replace("text-dark", "greenColor2");
            socialFirstTextValue.classList.add("d-none");

            let informationElemet = "", EnterInformationElement = "";

            for (let i = 0; i < socialDB.length; i++) {
                EnterInformationElement += ` <li class="rounded-2 greenBack2 text-white ps-4 d-flex align-items-center justify-content-start p-1 m-1 position-relative"><span class="mx-2">${socialDB[i].name}</span>  :  <span class="mx-2">${socialDB[i].address}</span> | <i class="mx-2 ri-${socialDB[i].icon}-fill"></i>   <i class="ri-close-fill fs-5 text-white itemSocial position-absolute top-0 start-0 ps-2" style="padding-top:.4rem;" data-social-id="${socialDB[i].id}"></i></li> `;
                socialDB[i].deleted = false;

                informationElemet += ` <li class="social-view greenBack2 rounded-2 text-white d-flex align-items-center justify-content-start p-1 m-1" style="flex : 1;cursor: pointer;"><span class="mx-2">${socialDB[i].name}</span>  :  <span class="mx-2">${socialDB[i].address}</span> | <i class="mx-2 ri-${socialDB[i].icon}-fill"></i></li> `;
            }

            $(".social-enter-information-socials-box").html(EnterInformationElement);
            $("#social-information-socials-box").html(informationElemet);

            $(".itemSocial").click(function (e) {
                this.parentElement.remove();
                let deleteId = $(this).attr("data-social-id");
                for (let i = 0; i < socialDB.length; i++) {
                    if (socialDB[i].id == deleteId) {
                        socialDB[i].deleted = true;
                    }
                }

                checkTemperryDeleteForDeletedAllSocial = true;

                for (let io = 0; io < socialDB.length; io++) {
                    if (socialDB[io].deleted !== true) {
                        checkTemperryDeleteForDeletedAllSocial = false;
                        break;
                    }
                }

                if (checkTemperryDeleteForDeletedAllSocial) {
                    socialFirstTextInForm.classList.remove("d-none");
                    $(".social-enter-information-socials-box").addClass("d-none");
                }
            });

            $(".social-view").click(function (e) {
                D.querySelector(".social-Container-Box").scrollIntoView({ behavior: 'smooth' });
                $("#social-information").slideToggle("slow");
                $("#social-enter-information").slideToggle("slow");

                $("#social-btn-change").addClass("d-none");

                fullBothSideAfterChangeSocial();

                socialNameInput.focus();

            });


        }


    }

    function emptyInputSocial() {
        socialNameInput.value = "";
        socialAddressInput.value = "";
        socialIconInput.value = "";
    }

    function getAllSocial() {
        $.ajax({
            type: "GET",
            url: "https://localhost:7120/api/socialnetworks",
            contentType: "application/json; charset=utf-8",
            success: (data) => {
                jQuery.each(data, (index, itemData) => {
                    socialDB.push({ id: itemData.id, name: itemData.name, address: itemData.address, icon: itemData.icon, deleted: false });
                });
                fullBothSideAfterChangeSocial();
            }
        })
    };

    //! change btn for go in form
    $("#social-btn-change").click(function () {
        D.querySelector(".social-Container-Box").scrollIntoView({ behavior: 'smooth' });
        $("#social-information").slideToggle("slow");
        $("#social-enter-information").slideToggle("slow");

        $("#social-btn-change").addClass("d-none");

        fullBothSideAfterChangeSocial();

        socialNameInput.focus();

    });

    //! back btn
    $("#social-enter-information-back-btn").click(function () {
        $("#social-information").slideToggle("slow");
        $("#social-enter-information").slideToggle("slow");

        $("#social-btn-change").removeClass("d-none");

        emptyInputSocial();

    });

    getAllSocial();

    //! save btn
    $("#social-enter-information-save-btn").click(function (e) {
        let ids = [];
        let socialDBLength = socialDB.length;
        for (let i = 0; i < socialDBLength; i++) {
            if (socialDB[i].deleted) {
                ids.push(socialDB[i].id);
            }
        }

        socialDB = socialDB.filter(item => item.deleted !== true);

        $.ajax({
            type: "DELETE",
            url: "https://localhost:7120/api/socialnetworks",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(ids),
            success: function (data) {
                if (data.success) {
                    fullBothSideAfterChangeSocial();
                    emptyInputSocial();
                }
            }
        });


        $("#social-information").slideToggle("slow");
        $("#social-enter-information").slideToggle("slow");

        $("#social-btn-change").removeClass("d-none");

    });

    //! add btn
    $("#social-add-icon").click(function (e) {

        let name = socialNameInput.value;
        let addressP = socialAddressInput.value;
        let iconP = socialIconInput.value;
        let priority = 0;

        var hasRecoardInDb = false;

        const testNameValueForHasedInDb1 = name.trim();
        const testNameValueForHasedInDb2 = testNameValueForHasedInDb1.replace(/\s+/g, ' ');
        const testNameValueForHasedInDb3 = testNameValueForHasedInDb2.toLowerCase();

        for (let h = 0; h < socialDB.length; h++) { //* Check to see if we don't have an object with this name in the database
            var testForSameRecord = socialDB[h].name.toLowerCase();
            if (testForSameRecord === testNameValueForHasedInDb3) {
                hasRecoardInDb = true;
            }
        }

        if (name !== "" && name !== null && !hasRecoardInDb) {

            $(".social-erorr-text-name").text("");
            $(".social-erorr-text-address").text("");
            $(".social-erorr-text-icon").text("");

            socialFirstTextInForm.classList.add("d-none");
            $(".social-enter-information-socials-box").removeClass("d-none");

            $.ajax({
                type: "POST",
                url: "https://localhost:7120/api/socialnetworks",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ Name: name, Address: addressP, Icon: iconP }),
                success: function (data) {
                    if (data.success) {
                        socialDB.push({ id: data.id, name: name, address: addressP, icon: iconP, deleted: false });
                        fullBothSideAfterChangeSocial();
                        emptyInputSocial();
                    }
                },
                error: function () {
                    $(".social-erorr-text-name").html("خطا در ارسال درخواست.");
                    success = false;
                }
            });
        }

        validatorDB.push({ inputValue: name.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: hasRecoardInDb, erorrTag: ".social-erorr-text-name" });
        validatorDB.push({ inputValue: addressP.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: false, erorrTag: ".social-erorr-text-address" });
        validatorDB.push({ inputValue: iconP.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: false, erorrTag: ".social-erorr-text-icon" });

        FormValidator();

        socialNameInput.focus();

    });

    $(".go-back-social").click(function () {
        D.querySelector(".social-Container-Box").scrollIntoView({ behavior: 'smooth' });
        $("#social-information").slideToggle("slow");
        $("#social-enter-information").slideToggle("slow");

        fullBothSideAfterChangeSocial();

        $("#social-btn-change").addClass("d-none");

        socialNameInput.focus();
    });

    // {} Project Net Work Container Script  -----------------------------------------------

    function fullBothSideAfterChangeProject() {
        $(".project-erorr-text-name").text("");
        $(".project-erorr-text-applicent").text("");
        $(".project-erorr-text-date").text("");
        $(".project-erorr-text-img").text("");

        if (projectDB.length == 0) {
            $(".project-enter-information-projects-box").html("");
            $("#project-information-projects-box").html("");
            $("#project-information-projects-box").addClass("d-none");
            projectFirstTextInForm.classList.remove("d-none");
            $(".project-enter-information-projects-box").addClass("d-none");
            projectFirstText.classList.replace("greenColor2", "text-dark");
            projectFirstTextValue.classList.remove("d-none");
        }

        if (!projectDB.length == 0) {
            $("#project-information-projects-box").html(" ");
            $("#project-information-projects-box").removeClass("d-none");
            $(".project-enter-information-projects-box").html(" ");
            projectFirstTextInForm.classList.add("d-none");
            $(".project-enter-information-projects-box").removeClass("d-none");
            projectFirstText.classList.replace("text-dark", "greenColor2");
            projectFirstTextValue.classList.add("d-none");

            let informationElemet = "", EnterInformationElement = "";
            //<img src="${projectDB[i].img}" class="rounded-3" stayl="width:120px;heigth:120px;"> 
            for (let i = 0; i < projectDB.length; i++) {
                EnterInformationElement += ` <li class="rounded-2 greenBack2 text-white ps-4 d-flex align-items-center justify-content-start p-1 m-1 position-relative"><span class="mx-2">${projectDB[i].name}</span>  :  <span class="mx-2">${projectDB[i].applicant}</span> | <span class="mx-2">${projectDB[i].date}</span> <i class="ri-close-fill fs-5 text-white itemProject position-absolute top-0 start-0 ps-2" style="padding-top:.4rem;" data-project-id="${projectDB[i].id}"></i></li> `;
                projectDB[i].deleted = false;

                informationElemet += ` <li class="project-view greenBack2 rounded-2 text-white d-flex align-items-center justify-content-start p-1 m-1" style="flex : 1;cursor: pointer;"><span class="mx-2">${projectDB[i].name}</span>  :  <span class="mx-2">${projectDB[i].applicant}</span> | <span class="mx-2">${projectDB[i].date}</span> </li> `;
            }

            $(".project-enter-information-projects-box").html(EnterInformationElement);
            $("#project-information-projects-box").html(informationElemet);

            $(".itemProject").click(function (e) {
                this.parentElement.remove();
                let deleteId = $(this).attr("data-project-id");
                for (let i = 0; i < projectDB.length; i++) {
                    if (projectDB[i].id == deleteId) {
                        projectDB[i].deleted = true;
                    }
                }

                checkTemperryDeleteForDeletedAllProject = true;

                for (let io = 0; io < projectDB.length; io++) {
                    if (projectDB[io].deleted !== true) {
                        checkTemperryDeleteForDeletedAllProject = false;
                        break;
                    }
                }

                if (checkTemperryDeleteForDeletedAllProject) {
                    projectFirstTextInForm.classList.remove("d-none");
                    $(".project-enter-information-projects-box").addClass("d-none");
                }
            });

            $(".project-view").click(function (e) {
                D.querySelector(".project-Container-Box").scrollIntoView({ behavior: 'smooth' });
                $("#project-information").slideToggle("slow");
                $("#project-enter-information").slideToggle("slow");

                $("#project-btn-change").addClass("d-none");

                fullBothSideAfterChangeProject();

                projectNameInput.focus();

            });


        }


    }

    function emptyInputProject() {
        projectNameInput.value = "";
        projectApplicantInput.value = "";
        projectDateInput.value = "";
        projectImgInput.value = "";
    }

    function getAllProject() {
        $.ajax({
            type: "GET",
            url: "https://localhost:7120/api/projects",
            contentType: "application/json; charset=utf-8",
            success: (data) => {
                jQuery.each(data, (index, itemData) => {
                    //img: itemData.img,
                    projectDB.push({ id: itemData.id, name: itemData.name, applicant: itemData.applicant, date: itemData.date, deleted: false });
                });
                fullBothSideAfterChangeProject();
            }
        })
    };

    //! change btn for go in form
    $("#project-btn-change").click(function () {
        D.querySelector(".project-Container-Box").scrollIntoView({ behavior: 'smooth' });

        $("#project-information").slideToggle("slow");
        $("#project-enter-information").slideToggle("slow");

        $("#project-btn-change").addClass("d-none");

        fullBothSideAfterChangeProject();

        projectNameInput.focus();

    });

    //! back btn
    $("#project-enter-information-back-btn").click(function () {
        $("#project-information").slideToggle("slow");
        $("#project-enter-information").slideToggle("slow");

        $("#project-btn-change").removeClass("d-none");

        emptyInputProject();

    });

    getAllProject();

    //! save btn
    $("#project-enter-information-save-btn").click(function (e) {
        let ids = [];
        let projectDBLength = projectDB.length;
        for (let i = 0; i < projectDBLength; i++) {
            if (projectDB[i].deleted) {
                ids.push(projectDB[i].id);
            }
        }

        projectDB = projectDB.filter(item => item.deleted !== true);


        $.ajax({
            type: "DELETE",
            url: "https://localhost:7120/api/projects",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(ids),
            success: function (data) {
                if (data.success) {
                    fullBothSideAfterChangeProject();
                    emptyInputProject();
                }
            }
        });


        $("#project-information").slideToggle("slow");
        $("#project-enter-information").slideToggle("slow");

        $("#project-btn-change").removeClass("d-none");

    });

    //! add btn
    $("#project-add-icon").click(function (e) {

        let name = projectNameInput.value;
        let applicantP = projectApplicantInput.value;
        let dateP = projectDateInput.value;
        //let imgP = projectImgInput.value;
        let priority = 0;

        var hasRecoardInDb = false;

        const testNameValueForHasedInDb1 = name.trim();
        const testNameValueForHasedInDb2 = testNameValueForHasedInDb1.replace(/\s+/g, ' ');
        const testNameValueForHasedInDb3 = testNameValueForHasedInDb2.toLowerCase();

        for (let h = 0; h < projectDB.length; h++) { //* Check to see if we don't have an object with this name in the database
            var testForSameRecord = projectDB[h].name.toLowerCase();
            if (testForSameRecord === testNameValueForHasedInDb3) {
                hasRecoardInDb = true;
            }
        }

        if (name !== "" && name !== null && !hasRecoardInDb) {

            $(".project-erorr-text-name").text("");
            $(".project-erorr-applicant-name").text("");
            $(".project-erorr-date-name").text("");
            $(".project-erorr-img-name").text("");

            projectFirstTextInForm.classList.add("d-none");
            $(".project-enter-information-projects-box").removeClass("d-none");

            $.ajax({
                type: "POST",
                url: "https://localhost:7120/api/projects",
                contentType: "application/json; charset=utf-8",
                //, Img: imgP
                data: JSON.stringify({ Name: name, Applicant: applicantP, Date: dateP, Img : "ko" }),
                success: function (data) {
                    if (data.success) {
                        //img: imgP,
                        projectDB.push({ id: data.id, name: name, applicant: applicantP, date: dateP, deleted: false });
                        fullBothSideAfterChangeProject();
                        emptyInputProject();
                    }
                },
                error: function () {
                    $(".project-erorr-text-name").html("خطا در ارسال درخواست.");
                    success = false;
                }
            });
        }

        validatorDB.push({ inputValue: name.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: hasRecoardInDb, erorrTag: ".project-erorr-text-name" });
        validatorDB.push({ inputValue: applicantP.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: false, erorrTag: ".project-erorr-text-applicant" });
        validatorDB.push({ inputValue: dateP.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: false, erorrTag: ".project-erorr-text-date" });
        //validatorDB.push({ inputValue: imgP.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: false, erorrTag: ".project-erorr-text-img" });

        FormValidator();

        projectNameInput.focus();

    });

    $(".go-back-project").click(function () {
        D.querySelector(".project-Container-Box").scrollIntoView({ behavior: 'smooth' });
        $("#project-information").slideToggle("slow");
        $("#project-enter-information").slideToggle("slow");

        fullBothSideAfterChangeProject();

        $("#project-btn-change").addClass("d-none");

        projectNameInput.focus();
    });

    // {} Education Container Script  -----------------------------------------------

    function createFormForChangeAnyRecoardEducation(erID , erMID) {
        
        $("#education-change-information-recoard").html("");

       /* const educationRecoardChanged = $(`#${erID}`);*/
        let numberInput = parseFloat(erMID);


        $.ajax({
            type: "GET",
            url: "https://localhost:7120/api/educations/" + numberInput,
            contentType: "application/json; charset=utf-8",
            success: (data) => {
                // img : itemDate.img
                let formChangeEducation = `

                  <div class="education-change-information-recoard-form w-100 d-flex align-items-start justify-content-start flex-column gap-3 ps-4 position-relative">
                            <div id="askForDeleteEducation" class="position-absolute top-0 start-0 w-100 h-100 d-flex align-items-center flex-column gap-3 justify-content-center d-none" style="background: rgba(33, 33, 33, 0.549);z-index:100;">
                                <div class="textBox">
                                    <span class="text-white">
                                        آیا از حذف این مدرک تحصیلی مطمئن هستید ؟
                                    </span>
                                </div>
                                <div class="btnBox">
                                    <button id="noAsk" class="p-2 px-4 mx-2 rounded-2 fs-6 greenBack2 text-white" style="cursor: pointer;">خیر</button>
                                    <button id="yesAsk" class="p-2 px-4 mx-2 rounded-2 fs-6 greenBack1 text-dark" style="cursor: pointer;">بله</button>
                                </div>
                            </div>
                            <div class="name d-flex w-100 flex-column justify-content-start gap-1 align-items-start">
                                <span class="me-1">
                                    نام مدرک : <small class="greenColor2">*</small>
                                </span>
                                <div class="education-change-name-input-box d-flex w-75">
                                    <input type="text" value="${data.name}" class="whiteBack1 text-dark fs-6 p-2 rounded-2" style="width: 80.7%;" spellcheck="false" placeholder="کاردانی کامپیوتر . javaScript . دوره ...">
                                </div>
                                <span class="me-1 education-change-erorr-text-name text-danger">

                                </span>
                            </div>
                            <div class="location d-flex w-100 flex-column justify-content-start gap-1 align-items-start">
                                <span class="me-1">
                                    لوکیشن : <small class="greenColor2">*</small>
                                </span>
                                <div class="education-change-location-input-box d-flex w-75">
                                    <input type="text" value="${data.location}" class="whiteBack1 text-dark fs-6 p-2 rounded-2" style="width: 80.7%;" spellcheck="false" placeholder="microsoft . دانشگاه . اموزشگاه ...">
                                </div>
                                <span class="me-1 education-change-erorr-text-location text-danger">

                                </span>
                            </div>
                            <div class="date d-flex w-100 flex-column justify-content-start gap-1 align-items-start">
                                <span class="me-1">
                                    تاریخ : <small class="greenColor2">*</small>
                                </span>
                                <div class="education-change-date-input-box d-flex w-75">
                                    <input type="text" value="${data.date}" class="whiteBack1 text-dark fs-6 p-2 rounded-2" style="width: 80.7%;" spellcheck="false" placeholder="1400/3/14 . 1389 ...">
                                </div>
                                <span class="me-1 education-change-erorr-text-date text-danger">

                                </span>
                            </div>
                            <div class="img d-flex w-100 flex-column justify-content-start gap-1 align-items-start">
                                <span class="me-1">
                                    عکس مدرک : <small class="greenColor2">( اختیاری )</small>
                                </span>
                                <div class="education-change-img-input-box d-flex w-75">
                                    <input type="file" class="whiteBack1 text-dark fs-6 p-2 rounded-2" spellcheck="false" style="width: 80.7%;">
                                </div>
                            </div>
                            <div class="btn-box d-flex w-100 justify-content-end gap-1 align-items-start">
                                <span id="education-change-enter-information-delete-btn" class="education-change-enter-information-delete-btn p-2 px-4 rounded-2 fs-6 greenBack1 text-dark" style="cursor: pointer;">حذف</span>
                                <span id="education-change-enter-information-back-btn" class="education-change-enter-information-back-btn p-2 px-4 rounded-2 fs-6 greenBack2 text-white" style="cursor: pointer;">انصراف</span>
                                <span id="education-change-enter-information-save-btn" class="education-change-enter-information-save-btn p-2 px-4 rounded-2 fs-6 greenBack1 text-dark" style="cursor: pointer;">ذخیره</span>
                            </div>
                        </div>
                `;
                $("#education-change-information-recoard").html(formChangeEducation);

                $("#education-change-enter-information-delete-btn").click(function (e) {
                    $("#askForDeleteEducation").removeClass("d-none");
                    $("body").addClass("overflow-hidden");
                });

                $("#yesAsk").click(function (e) {

                    $.ajax({
                        type: "DELETE",
                        url: "https://localhost:7120/api/educations/" + numberInput ,
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(erID),
                        success: function (data) {
                            if (data.success) {
                                $("#askForDeleteEducation").addClass("d-none");
                                $("body").removeClass("overflow-hidden");

                                $("#education-change-information-recoard").html("");

                                $("#education-information").slideToggle("slow");
                                $("#education-change-information-recoard").slideToggle("slow");

                                educationDB = [];

                    

                                $("#education-btn-change").removeClass("d-none");

                                fullBothSideAfterChangeEducation();
                                getAllEducation();

                            }
                        }
                    });

                });
                $("#noAsk").click(function (e) {
                    $("#askForDeleteEducation").addClass("d-none");
                    $("body").removeClass("overflow-hidden");
                });

                $("#education-change-enter-information-back-btn").click(function (e) {
                    $("#education-change-information-recoard").html("");
                    $("#education-information").slideToggle("slow");
                    $("#education-change-information-recoard").slideToggle("slow");
                    $("#education-btn-change").removeClass("d-none");
                });

                $("#education-change-enter-information-save-btn").click(function (e) {

                    //let numberInputChange = parseFloat(erMID);
                    let numberInputChange = parseInt(erMID);

                    let nameP = D.querySelector(".education-change-name-input-box input"),
                        locationP = D.querySelector(".education-change-location-input-box input"),
                        dateP = D.querySelector(".education-change-date-input-box input");
                    //imgP = D.querySelector(".education-change-img-input-box input");

                    if (nameP !== "" && nameP !== null) {

                        $.ajax({
                            type: "PUT",
                            url: "https://localhost:7120/api/educations/" + numberInputChange,
                            contentType: "application/json; charset=utf-8",
                            data: JSON.stringify({ Id: numberInputChange, Name: nameP.value, Location: locationP.value, Date: dateP.value, Img: "" }),
                            success: function (data) {
                                if (data.success) {
                                    $("#education-change-information-recoard").html("");
                                    $("#education-information").slideToggle("slow");
                                    $("#education-change-information-recoard").slideToggle("slow");
                                    $("#education-btn-change").removeClass("d-none");
                                    educationDB = [];
                                    getAllEducation();
                                }
                            },
                            error: function () {
                                $(".education-change-erorr-text-name").html("خطا در ارسال درخواست.");
                                success = false;
                            }
                        });
                    }

                    validatorDB.push({ inputValue: nameP, checkEmpty: true, checkEqual: false, chackHasBefor: false, erorrTag: ".education-change-erorr-text-name" });
                    validatorDB.push({ inputValue: locationP, checkEmpty: true, checkEqual: false, chackHasBefor: false, erorrTag: ".education-change-erorr-text-location" });
                    validatorDB.push({ inputValue: dateP, checkEmpty: true, checkEqual: false, chackHasBefor: false, erorrTag: ".education-change-erorr-text-date" });

                    FormValidator();
                });

            }
        });

    }

    $("#education-btn-sortable").click(function () {

        D.querySelector(".education-Container-Box").scrollIntoView({ behavior: 'smooth' });

        $(".sortable-list-education-box").html("");

        sortedEducationIds = [];

        let sorthTable = "";

        for (let i = 0; i < educationDB.length; i++) {

            sorthTable += ` 
                <li class=" education-change-view rounded-2 bg-white text-dark d-flex align-items-center justify-content-start p-1 m-1 sortable-item-education" style="flex : 1;cursor: pointer;" data-education-id="${educationDB[i].id}">
                     <div id="text-box-education-any-recoard" class="d-flex align-items-center justify-content-between">
                        <i class="ri-drag-move-2-fill fs-2 greenColor-2"></i>
                        <div class="d-flex p-2">
                           <span class="mx-2">${educationDB[i].name}</span>
                           :
                           <span class="mx-2">${educationDB[i].location}</span>
                           --
                           <span class="mx-2">${educationDB[i].date}</span>
                        </div>
                     </div>
                </li> `;
            }

        $(".sortable-list-education-box").html(sorthTable);

        $("#education-sortable-box").removeClass("d-none");

    });

    $("#sortable-list-education").sortable({
        update: function (event, ui) {

            sortedEducationIds = [];

            $(".sortable-item-education").each(function () {
                sortedEducationIds.push($(this).data("education-id"));
            });

        }
    });

    $("#education-sorth-back-btn").click(function () {
        sortedEducationIds = [];

        $("#education-sortable-box").addClass("d-none");

    });

    $("#education-sorth-save-btn").click(function () {
          if (sortedEducationIds.length != 0) {
               $.ajax({
                   type: 'PUT',
                   url: 'https://localhost:7120/api/educations',
                   contentType: "application/json; charset=utf-8",
                   data: JSON.stringify(sortedEducationIds),
                   success: function (data) {
                       if (data.success) {
                           educationDB = [];
                           getAllEducation();
                          
                       }
                   }
               });
        }
        $("#education-sortable-box").addClass("d-none");

    });

    function fullBothSideAfterChangeEducation() {



        $(".education-erorr-text-name").text("");
        $(".education-erorr-text-location").text("");
        $(".education-erorr-text-date").text("");

        if (educationDB.length == 0) {
            $(".education-enter-information-educations-box").html("");
            $("#education-information-educations-box").html("");
            $("#education-information-educations-box").addClass("d-none");
            $(".education-enter-information-educations-box").addClass("d-none");
            educationFirstText.classList.replace("greenColor2", "text-dark");
            educationFirstTextValue.classList.remove("d-none");
        }

        if (!educationDB.length == 0) {
            $("#education-information-educations-box").html(" ");
            $("#education-information-educations-box").removeClass("d-none");
            $(".education-enter-information-educations-box").html(" ");
            $(".education-enter-information-educations-box").removeClass("d-none");
            educationFirstText.classList.replace("text-dark", "greenColor2");
            educationFirstTextValue.classList.add("d-none");

            let informationElemet = "";

            for (let i = 0; i < educationDB.length; i++) {
   
                         //< !-- < img class="w-100 h-100" src = "${education[i].img}" > -->
                         

                educationDB[i].deleted = false;

                informationElemet += ` 
                <li atrr-id="${educationDB[i].name}" atrr-main-id="${educationDB[i].id}" id="${educationDB[i].name}" class=" education-change-view rounded-2 greenBack2 text-white d-flex align-items-center justify-content-start p-1 m-1" style="flex : 1;cursor: pointer;">
                     <div id="img-box-education-any-recoard" class="mx-3 d-flex align-items-center justifuy-content-center overflow-hidden rounded-2 gap-1" style="width:110px;hegth:110px;">
                          <img class="w-100 h-100" src="image/defult-image.jpg"/>
                     </div>
                     <div id="text-box-education-any-recoard" class="d-flex flex-column gap-1">
                        <span class="mx-2">${educationDB[i].name}</span>
                        <div class="d-flex p-2">
                           <span class="mx-2">${educationDB[i].location}</span>
                           --
                           <span class="mx-2">${educationDB[i].date}</span>
                        </div>
                     </div>
                </li> `;

            }
            $("#education-information-educations-box").html(informationElemet);

            $(".education-change-view").click(function (e) {
                D.querySelector(".education-Container-Box").scrollIntoView({ behavior: 'smooth' });
                $("#education-information").slideToggle("slow");
                $("#education-change-information-recoard").slideToggle("slow");

                $("#education-btn-change").addClass("d-none");

                let EducationRecoardID = $(this).attr("atrr-id");
                let EducationRecoardMainId = $(this).attr("atrr-main-id");

                createFormForChangeAnyRecoardEducation(EducationRecoardID, EducationRecoardMainId);

                sortedEducationIds = [];

            });

            $("#education-btn-sortable")

        }

    }

    function emptyInputEducation() {
        educationNameInput.value = "";
        educationLocationInput.value = "";
        educationDateInput.value = "";
        educationImgInput.value = "";
    }

    function getAllEducation() {
        $.ajax({
            type: "GET",
            url: "https://localhost:7120/api/educations",
            contentType: "application/json; charset=utf-8",
            success: (data) => {
                jQuery.each(data, (index, itemData) => {
                    // img : itemDate.img
                    educationDB.push({ id: itemData.id, name: itemData.name, location: itemData.location, date: itemData.date, priority: itemData.priority });
                });
                fullBothSideAfterChangeEducation();
            }
        });
    };

    //! change btn for go in form
    $("#education-btn-change").click(function () {

        D.querySelector(".education-Container-Box").scrollIntoView({ behavior: 'smooth' });

        $("#education-information").slideToggle("slow");
        $("#education-enter-information").slideToggle("slow");

        $("#education-btn-change").addClass("d-none");

        fullBothSideAfterChangeEducation();

        educationNameInput.focus();

    });

    //! back btn
    $("#education-enter-information-back-btn").click(function () {

        $("#education-information").slideToggle("slow");
        $("#education-enter-information").slideToggle("slow");

        $("#education-btn-change").removeClass("d-none");

        emptyInputEducation();

    });

    getAllEducation();
    
    //! add btn
    $("#education-add-icon").click(function (e) {

        let name = educationNameInput.value;
        let locationP = educationLocationInput.value;
        let dateP = educationDateInput.value;
        let imgP = educationImgInput.value;
        let priority = 0;

        var hasRecoardInDb = false;

        const testNameValueForHasedInDb1 = name.trim();
        const testNameValueForHasedInDb2 = testNameValueForHasedInDb1.replace(/\s+/g, ' ');
        const testNameValueForHasedInDb3 = testNameValueForHasedInDb2.toLowerCase();

        for (let h = 0; h < educationDB.length; h++) { //* Check to see if we don't have an object with this name in the database
            var testForSameRecord = educationDB[h].name.toLowerCase();
            if (testForSameRecord === testNameValueForHasedInDb3) {
                hasRecoardInDb = true;
            }
        }

        if (name !== "" && name !== null && !hasRecoardInDb) {

            $(".education-erorr-text-name").text("");
            $(".education-erorr-text-location").text("");
            $(".education-erorr-text-date").text("");

            $(".education-enter-information-educations-box").removeClass("d-none");

            if (educationDB.length != 0) {
                priorty = getMax(educationDB, "priority").priority;
                priorty += 1;
            } else {
                priorty = 1;
            }

          

            $.ajax({
                type: "POST",
                url: "https://localhost:7120/api/educations",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ Name: name, Location: locationP, Date: dateP, Img: "" }),
                success: function (data) {
                    if (data.success) {
                        educationDB.push({ id: data.id, name: name, location: locationP, date: dateP, priority: priorty });
                        fullBothSideAfterChangeEducation();
                        emptyInputEducation();
                        alert("یک مدرک جدید اضافه شد . برای مشاهده همه مدرک ها دکمه بازگشت را بزنید .");

                    }
                },
                error: function () {
                    $(".education-education-text-name").html("خطا در ارسال درخواست.");
                    success = false;
                }
            });


        }

        validatorDB.push({ inputValue: name.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: hasRecoardInDb, erorrTag: ".education-erorr-text-name" });
        validatorDB.push({ inputValue: locationP.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: false, erorrTag: ".education-erorr-text-location" });
        validatorDB.push({ inputValue: dateP.trim(), checkEmpty: true, checkEqual: false, chackHasBefor: false, erorrTag: ".education-erorr-text-date" });

        FormValidator();

        educationNameInput.focus();
    });

    $(".go-back-education").click(function () {

        D.querySelector(".education-Container-Box").scrollIntoView({ behavior: 'smooth' });

        $("#education-information").slideToggle("slow");
        $("#education-enter-information").slideToggle("slow");

        fullBothSideAfterChangeEducation();

        $("#education-btn-change").addClass("d-none");

        educationNameInput.focus();
    });

});