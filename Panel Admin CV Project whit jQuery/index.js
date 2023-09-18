const D = document;

//TODO Title Container Scripits


//! title enter information
const titleEnterInformation = D.querySelector(".title-enter-information");
const titleEnterInformationSaveBtn = D.querySelector(".title-enter-information-save-btn");
const titleEnterInformationBackBtn = D.querySelector(".title-enter-information-back-btn");

const titleNameInput = D.querySelector(".title-enter-information-form .name input");
const titleProvisionInput = D.querySelector(".title-enter-information-form .provision input");
const titleAbouteMeInput = D.querySelector(".title-enter-information-form .aboute-me textarea");
const titleCupCoffeeInput = D.querySelector(".title-enter-information-form .cup-coffee input");
const titleCompleteProjectInput = D.querySelector(".title-enter-information-form .complete-project input");
const titleCvFileInput = D.querySelector(".title-enter-information-form .cv-file input");

var titleInputNameBValue , titleInputProvisionBValue , titleInputAbouteMeBValue , titleInputCupCoffeeBValue , titleInputCompleteProjectBValue;                   

//! title information
const titleBtnChange = D.querySelector(".title-btn-change");
const titleInformation = D.querySelector(".title-information");
const goBackTitle = D.querySelectorAll(".go-back-title");

const titleName = D.querySelector(".title-person-name-lable");
const titleNameValue = D.querySelector(".title-name-value");
const titleProvision = D.querySelector(".title-provision-lable");
const titleProvisionValue = D.querySelector(".title-provision-value");
const titleAbouteMe = D.querySelector(".title-aboute-me-lable");
const titleAbouteMeValue = D.querySelector(".title-aboute-me-value");
const titleCupCoffee = D.querySelector(".title-cup-coffee-lable");
const titleCupCoffeeValue = D.querySelector(".title-cup-coffee-value");
const titleCompleteProject = D.querySelector(".title-complete-project-lable");
const titleCompleteProjectValue = D.querySelector(".title-complete-project-value");
const titleCvFile = D.querySelector(".title-cv-file-lable");
const titleCvFileValue = D.querySelector(".title-cv-file-value");

const titleInputNameFValue = titleNameValue.textContent;
const titleInputProvisionFValue = titleProvisionValue.textContent;
const titleInputAbouteMeFValue = titleAbouteMeValue.textContent;  
const titleInputCupCoffeeFValue = titleCupCoffeeValue.textContent;  
const titleInputCompleteProjectFValue = titleCompleteProjectValue.textContent;  


titleBtnChange.addEventListener("click" , () => { //! title container change btn for show form
    
    titleBtnChange.classList.add("d-none");

    //* if we do have nun value in show part then enter part is emoty in the first of job
    if(titleNameValue.classList.contains("greenColor2")) {titleNameInput.value = "";}  
    if(titleProvisionValue.classList.contains("greenColor2")) titleProvisionInput.value = "";
    if(titleAbouteMeValue.classList.contains("greenColor2")) titleAbouteMeInput.value = "";
    if(titleCupCoffeeValue.classList.contains("greenColor2")) titleCupCoffeeInput.value = "";
    if(titleCompleteProjectValue.classList.contains("greenColor2")) titleCompleteProjectInput.value = "";

    titleInformation.classList.add("d-none");
    titleEnterInformation.classList.remove("d-none");
    
});

titleEnterInformationSaveBtn.addEventListener("click" , () => { //! save btn in form from title container

    const nameValue = titleNameInput.value;
    const jobTitleValue = titleProvisionInput.value;
    const abouteMeValue = titleAbouteMeInput.value;
    const cupCoffeeValue = titleCupCoffeeInput.value;
    const completeProjectValue = titleCompleteProjectInput.value;
    
    if (nameValue !== "" && nameValue !== null) { //* Name
        titleInputNameBValue = nameValue;
        titleNameValue.textContent = titleInputNameBValue;
        titleName.classList.replace("text-dark" , "greenColor2" );
        titleNameValue.classList.replace("greenColor2" , "text-dark");
        titleNameInput.value = titleInputNameBValue
    } else if (nameValue == "" || nameValue == null) {
        titleNameValue.textContent = titleInputNameFValue;
        titleName.classList.replace("greenColor2" , "text-dark");
        titleNameValue.classList.replace( "text-dark" , "greenColor2");
    }
    

    if (jobTitleValue !== "" && jobTitleValue !== null) { //* Provision
        titleInputProvisionBValue = jobTitleValue
        titleProvisionValue.textContent = titleInputProvisionBValue;
        titleProvision.classList.replace("text-dark" , "greenColor2");
        titleProvisionValue.classList.replace("greenColor2" , "text-dark");
        titleProvisionInput.value = titleInputProvisionBValue
    } else if (jobTitleValue == "" || jobTitleValue == null) {
        titleProvisionValue.textContent = titleInputProvisionFValue;
        titleProvision.classList.replace( "greenColor2" , "text-dark" );
        titleProvisionValue.classList.replace("text-dark" , "greenColor2");
    }

    if (abouteMeValue !== "" && abouteMeValue !== null) { //* Aboute Me
        titleInputAbouteMeBValue = abouteMeValue
        titleAbouteMeValue.textContent = titleInputAbouteMeBValue;
        titleAbouteMe.classList.replace("text-dark" , "greenColor2");
        titleAbouteMeValue.classList.replace("greenColor2" , "text-dark");
        titleAbouteMeInput.value = titleInputAbouteMeBValue
    } else if (abouteMeValue == "" || abouteMeValue == null) {
        titleAbouteMeValue.textContent = titleInputAbouteMeFValue;
        titleAbouteMe.classList.replace("greenColor2" , "text-dark")
        titleAbouteMeValue.classList.replace("text-dark" , "greenColor2" );
    }

    if (cupCoffeeValue !== "" && cupCoffeeValue !== null) { //* Cup Coffee
        titleInputCupCoffeeBValue = cupCoffeeValue;
        titleCupCoffeeValue.textContent = titleInputCupCoffeeBValue;
        titleCupCoffee.classList.replace("text-dark" , "greenColor2");
        titleCupCoffeeValue.classList.replace("greenColor2" , "text-dark");
        titleCupCoffeeInput.value = titleInputCupCoffeeBValue
    } else if (cupCoffeeValue == "" || cupCoffeeValue == null) {
        titleCupCoffeeValue.textContent = titleInputCupCoffeeFValue;
        titleCupCoffee.classList.replace("greenColor2" , "text-dark")
        titleCupCoffeeValue.classList.replace("text-dark" , "greenColor2");
    }

    if (completeProjectValue !== "" && completeProjectValue !== null) { //* Complete Project
        titleInputCompleteProjectBValue = completeProjectValue;
        titleCompleteProjectValue.textContent = titleInputCompleteProjectBValue;
        titleCompleteProject.classList.replace("text-dark" , "greenColor2");
        titleCompleteProjectValue.classList.replace("greenColor2" , "text-dark");
        titleCompleteProjectInput.value = titleInputCompleteProjectBValue
    } else if (completeProjectValue == "" || completeProjectValue == null) {
        titleCompleteProjectValue.textContent = titleInputCompleteProjectFValue;
        titleCompleteProject.classList.replace("greenColor2" , "text-dark");
        titleCompleteProjectValue.classList.replace("text-dark" , "greenColor2");
    }

    if (titleCvFileInput.files.length > 0) { //* File Cv
        titleCvFileValue.textContent = "فایل رزومه اضافه شد";
        titleCvFile.classList.replace("text-dark" , "greenColor2");
        titleCvFileValue.classList.replace("greenColor2" , "text-dark");
    } else { 
        titleCvFile.classList.replace("greenColor2" , "text-dark");
        titleCvFileValue.classList.replace("text-dark" , "greenColor2");
    }

    titleBtnChange.classList.remove("d-none");

    titleInformation.classList.remove("d-none");
    titleEnterInformation.classList.add("d-none");
});


titleEnterInformationBackBtn.addEventListener("click" , () => { //! back btn in form from title container

    //* change input vlue in form inter for back btn if haved value befoor this
    if(!titleNameValue.classList.contains("greenColor2")) titleNameInput.value = titleInputNameBValue; 
    if(!titleProvisionValue.classList.contains("greenColor2")) titleProvisionInput.value = titleInputProvisionBValue;
    if(!titleAbouteMeValue.classList.contains("greenColor2")) titleAbouteMeInput.value = titleInputAbouteMeBValue;
    if(!titleCupCoffeeValue.classList.contains("greenColor2")) titleCupCoffeeInput.value = titleInputCupCoffeeBValue;
    if(!titleCompleteProjectValue.classList.contains("greenColor2")) titleCompleteProjectInput.value = titleInputCompleteProjectBValue;

    titleInformation.classList.remove("d-none");
    titleEnterInformation.classList.add("d-none");

    titleBtnChange.classList.remove("d-none");
});

goBackTitle.forEach(btn => { //! for all text link in title container for show form
    btn.addEventListener("click" , () => {

        titleBtnChange.classList.add("d-none");

        //* if we do have nun value in show part then enter part is emoty in the first of job
        if(titleNameValue.classList.contains("greenColor2")) {titleNameInput.value = "";}  
        if(titleProvisionValue.classList.contains("greenColor2")) titleProvisionInput.value = "";
        if(titleAbouteMeValue.classList.contains("greenColor2")) titleAbouteMeInput.value = "";
        if(titleCupCoffeeValue.classList.contains("greenColor2")) titleCupCoffeeInput.value = "";
        if(titleCompleteProjectValue.classList.contains("greenColor2")) titleCompleteProjectInput.value = "";

        titleInformation.classList.add("d-none");
        titleEnterInformation.classList.remove("d-none");
    });
});


//TODO Skill Container Script

const skillNameInput = D.querySelector(".skill-enter-information-form .name input"),
skillLevelSelect = D.querySelector(".skill-enter-information-form .level select"),
skillLevelSelectOptions = skillLevelSelect.querySelectorAll("option"),
skillFirstTextInForm = D.querySelector(".skill-enter-information-form .first-text span"),
skillErorrTextName = D.querySelector(".skill-erorr-text-name"),
skillErorrTextLevel = D.querySelector(".skill-erorr-text-level"),
skillFirstText = D.querySelector(".skill-first-text-lable"),
skillFirstTextValue = D.querySelector(".skill-first-text-value");

const skillInputFirstTextFValue = skillFirstTextValue.textContent;

var checkTemperryDeleteForDeletedAllSkill = true; //* for that time all skill is deleted and we wanted first text in form come back

let selectedOptionFirstValue;

var skillDB = []; //* skill database 
var sortedSkillIds = []; //* skill database for priority

const nameErorrText = "یک متن برای مهارت خود وارد کنید .",
levelErorrText = "یک سطح برای مهارت خود انتخاب کنید",
sameRecoardErorrText = "این مهارت قبلا ثبت شده .";

$(document).ready(() => {
    //TODO defult seting
    $("#skill-enter-information").slideUp();

    //TODO
    const fullBothSideAfterChange = () => {

        skillErorrTextName.innerText = " " ;
        skillErorrTextLevel.innerText = " ";

        if (skillDB.length == 0) {
            $("#skill-enter-information-skills-box").html(" ");
            $("#skill-information-skills-box").html(" ");
            $("#skill-information-skills-box").addClass("d-none");
            skillFirstTextInForm.classList.remove("d-none");
            $("#skill-enter-information-skills-box").addClass("d-none");
            skillFirstText.classList.replace("greenColor2" , "text-dark");
            skillFirstTextValue.classList.remove("d-none");
        }

        if (!skillDB.length == 0) {
            $("#skill-information-skills-box").html(" ");
            $("#skill-information-skills-box").removeClass("d-none");
            $("#skill-enter-information-skills-box").html(" ");
            skillFirstTextInForm.classList.add("d-none");
            $("#skill-enter-information-skills-box").removeClass("d-none");
            skillFirstText.classList.replace( "text-dark" , "greenColor2");
            skillFirstTextValue.classList.add("d-none");

            let informationElemet = "" , EnterInformationElement = "";

            for (let i = 0; i < skillDB.length; i++) {
                EnterInformationElement += ` <li class="rounded-2 greenBack2 text-white d-flex align-items-center justify-content-center p-1 m-1 sortable-item" data-skillPri-id="${skillDB[i].id}"><span class="mx-2">${skillDB[i].name}</span>  |  <span class="mx-2">${skillDB[i].value}</span>   <i class="ri-close-fill fs-5 text-white itemSkill ${dis}" data-skill-id="${skillDB[i].id}"></i></li>; `;
                skillDB[i].deleted = false;

                informationElemet += ` <li id="skill-view" class="rounded-2 greenBack2 text-white d-flex align-items-center justify-content-center p-1 m-1"><span class="mx-2">${skillDB[i].name}</span>  |  <span class="mx-2">${skillDB[i].value}</span></li>; `;   
            }

            $("#skill-enter-information-skills-box").html(EnterInformationElement);
            $("#skill-information-skills-box").html(informationElemet);
    
            $("#itemSkill").click(e => {
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
                    $("#skill-enter-information-skills-box").addClass("d-none");
                }
            });

            $("#skill-view").addEventListener("click" , fullBothSideAfterChange);
        }


    }

    const emptyInputSkill = () => {
        skillNameInput.value = "";
        skillLevelSelectOptions.forEach(option => {
            option.selected = false;
            if(option.value === "choose") {
                skillLevelSelect.style.fontWeight = "200";
                option.selected = true;
            };
        });
    }

    const getAllSkill = () => {
        $.ajax({
            type: "GET",
            url: "https://localhost:7120/api/skills",
            contentType: "application/json; charset=utf-8",
            success: (data) => {
                jQuery.each(data, (index, itemData) => {
                    skillsDb.push({ id: itemData.id, name: itemData.name, value: itemData.skillValue, priority: itemData.priority, deleted: false });
                });
            }
        })
    };

    const getMax = (arr, prop) => {
        var max;
        for (var i = 0; i < arr.length; i++) {
            if (max == null || parseInt(arr[i][prop]) > parseInt(max[prop]))
                max = arr[i];
        }
        return max;
    }

    //! change btn for go in form
    $("#skill-btn-change").click(() => {

        $("#skill-information").slideToggle("slow");
        $("#skill-enter-information").slideToggle("slow");

        fullBothSideAfterChange();

        sortedSkillIds = [];

        skillNameInput.focus();

    });

    //! back btn
    $("#skill-enter-information-back-btn").click(() => {
        $("#skill-information").slideToggle("slow");
        $("#skill-enter-information").slideToggle("slow");

        emptyInputSkill();

        sortedSkillIds = [];
    });

    getAllSkill();

    $("#sortable-list").sortable({
        update: (event, ui) => {
  
            sortedSkillIds = [];
  
            $(".sortable-item").each(() => {
                sortedSkillIds.push($(this).data("skillpri-id"));
            });
  
        }
    });

    //! for change text style in select in form after chosse enather option
    skillLevelSelect.addEventListener("change" , () => skillLevelSelect.style.fontWeight = "400"); 

    //! save btn
    $("#skill-enter-information-save-btn").click( e => {
        let ids = [];

        let skillDBLength = skillDB.length;
        for (let i = 0; i < skillDBLength.length; i++) {
            if (skillDB[i].deleted) {
                ids.push(skillDB[id].id);
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
                    refreshSkillsDb();
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


    });

    //! add btn
    $("#skill-add-icon").click( e => {
        
        selectedOptionFirstValue = skillLevelSelect.querySelector("option:checked");

        let name = skillNameInput.value;
        let level = skillLevelSelect.querySelector("option:checked");
        let priority = 0;

        var hasRecoardInDb = false;

        const testNameValueForHasedInDb1 = name.trim();
        const testNameValueForHasedInDb2 = testNameValueForHasedInDb1.replace(/\s+/g , ' ');
        const testNameValueForHasedInDb3 = testNameValueForHasedInDb2.toLowerCase();

        for (let h = 0; h < skillDB.length; h++) { //* Check to see if we don't have an object with this name in the database
            var testForSameRecord = skillDB[h].name.toLowerCase();
            if (testForSameRecord === testNameValueForHasedInDb3) {
                hasRecoardInDb = true;
            }
        }

        if (skillLevelSelect && selectedOptionFirstValue.value !== "choose" && level !== "" && level !== null && !hasRecoardInDb) {
            
            skillErorrTextName.innerText(" ");
            skillErorrTextLevel.classList.innerText(" ");
            
            skillFirstTextInForm.classList.add("d-none");
            $("#skill-enter-information-skills-box").removeClass("d-none");

            if (skillDB.length != 0) {
                priorty = getMax(skillDB , "priorty").priority;
            }
            priorty += 1;

            $.ajax({
                type: "POST",
                url: "https://localhost:7120/api/skills",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ Name: name, SkillValue: level, IsActive: true }),
                success: function (data) {
                    if (data.success) {
                        skillDB.push({ id: data.id, name: name, level: level, priority: priority, deleted: false });
                        fullBothSideAfterChange();
                        emptyInputSkill();
                    }
                },
                error: function () {
                    $(".skill-erorr-text-level").html("خطا در ارسال درخواست.");
                    success = false;
                }
            });
        } else if ((nameValue === "" || nameValue === null) && (!skillLevelSelect || selectedOptionFirstValue.value === "choose")) {
            skillErorrTextName.innerText(`${sameRecoardErorrText}`);
            skillErorrTextLevel.classList.innerText(" ");
        } else if (hasRecoardInDb) {
            skillErorrTextName.innerText(`${nameErorrText}`);
            skillErorrTextLevel.classList.innerText(`${levelErorrText}`);
        } else if (nameValue === "" || nameValue === null) {
            skillErorrTextName.innerText(" ");
            skillErorrTextLevel.classList.innerText(`${levelErorrText}`);
        } else if (!skillLevelSelect || selectedOptionFirstValue.value === "choose") {
            skillErorrTextName.innerHtml(`<span>${nameErorrText}</span><br><span>${sameRecoardErorrText}</span> `);
            skillErorrTextLevel.classList.innerText(" ");
        }
    });

    $("#go-back-skill").click(() => {
        CheckThenGoEnterInformation();

        $("#skill-information").slideToggle("slow");
        $("#skill-enter-information").slideToggle("slow");

        fullBothSideAfterChange();

        sortedSkillIds = [];

        skillNameInput.focus();
    });

});




