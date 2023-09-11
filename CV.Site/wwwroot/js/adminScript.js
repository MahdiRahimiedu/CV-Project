
var skillsDb = [];
var cancelSkill = document.getElementById("cancel-skill");
var saveSkill = document.getElementById("save-skill");
var sortedSkillIds = [];
$(document).ready(function () {


    $("#btn-form-box").click(function () {

        $("#form-box-skill").fadeIn("slow");
        var aa = document.querySelectorAll(".itemSkill");
        aa.forEach(element => {
            element.classList.remove("d-none");
        });
        cancelSkill.classList.remove("d-none");
        saveSkill.classList.remove("d-none");

        $("#box-skill-clinet").addClass("d-none");
        $(".box-skill").removeClass("d-none");


        refreshSkillsDb("d-inline-block");

        sortedSkillIds = [];

    });

    $("#cancel-skill").click(function () {

        $("#form-box-skill").fadeOut("slow");
        var aa = document.querySelectorAll(".itemSkill");
        aa.forEach(element => {
            element.classList.add("d-none");
        });
        cancelSkill.classList.add("d-none");
        saveSkill.classList.add("d-none");

        //skillsDb.sort((a, b) => parseFloat(a.id) - parseFloat(b.id));

        refreshSkillsDb("d-none");

        emptyInputSkill();

        sortedSkillIds = [];


        $("#box-skill-clinet").removeClass("d-none");
        $(".box-skill").addClass("d-none");
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
    function refreshSkillsDb(dis) {

        let txt = "";
        for (let i = 0; i < skillsDb.length; i++) {

            txt += '<li class="bg-body-secondary d-inline-block ms-3 p-2 rounded sortable-item" data-skillPri-id="' + skillsDb[i].id + '" ><i class="ps-2 itemSkill ' + dis + '" data-skill-id="' + skillsDb[i].id + '">*</i>' + skillsDb[i].name + " | " + skillsDb[i].value + "  </li>";
            skillsDb[i].deleted = false;
        }
        $(".box-skill").html(txt);

        let txt2 = "";
        for (let i = 0; i < skillsDb.length; i++) {

            txt2 += '<li class="bg-body-secondary d-inline-block ms-3 p-2 rounded ">' + skillsDb[i].name + " | " + skillsDb[i].value + "  </li>";
        }

        $("#box-skill-clinet").html(txt2);

        $(".itemSkill").click(function (e) {
            this.parentElement.remove();
            let iddeleted = $(this).attr("data-skill-id");
            for (let i = 0; i < skillsDb.length; i++) {
                if (skillsDb[i].id == iddeleted) {
                    skillsDb[i].deleted = true;
                }
            }
        });
    }

    $("#save-skill").click(function (e) {
        let ids = [];


        let skillsDbLength = skillsDb.length;
        for (let i = 0; i < skillsDbLength; i++) {
            if (skillsDb[i].deleted) {
                ids.push(skillsDb[i].id);
            }
        }

        skillsDb = skillsDb.filter(item => item.deleted !== true)

        $.ajax({
            type: "DELETE",
            url: "https://localhost:7120/api/skills",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(ids),
            success: function (data) {
                if (data.success) {
                    refreshSkillsDb("d-none");
                    $("#form-box-skill").fadeOut("slow");
                    var aa = document.querySelectorAll(".itemSkill");
                    aa.forEach(element => {
                        element.classList.add("d-none");
                    });
                    cancelSkill.classList.add("d-none");
                    saveSkill.classList.add("d-none");
                    emptyInputSkill();
                }
                else {
                    console.log("error");
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
                        skillsDb = [];
                        getAllSkill();
                    }
                }
            });
        }

        $("#box-skill-clinet").removeClass("d-none");
        $(".box-skill").addClass("d-none");

    });

    $("#add-skill").click(function (e) {
        let name = $('input[name="nameSkill"]').val();
        let value = $('select[name="valueSkill"]').val();
        let priority = getMax(skillsDb, "priority").priority + 1;
        $.ajax({
            type: "POST",
            url: "https://localhost:7120/api/skills",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ Name: name, SkillValue: value, IsActive: true }),
            success: function (data) {
                if (data.success) {
                    skillsDb.push({ id: data.id, name: name, value: value, priority: priority, deleted: false });
                    refreshSkillsDb("d-inline-block");
                    emptyInputSkill();

                }

            },
            error: function () {
                $(".skill-erorr-text-level").html("خطا در ارسال درخواست.");
                success = false;
            }
        });





    });

    function emptyInputSkill() {
        $('input[name="nameSkill"]').val("");
        $('select[name="valueSkill"]').val("");
    }
    function getMax(arr, prop) {
        var max;
        for (var i = 0; i < arr.length; i++) {
            if (max == null || parseInt(arr[i][prop]) > parseInt(max[prop]))
                max = arr[i];
        }
        return max;
    }

    function getAllSkill() {
        $.ajax({
            type: "GET",
            url: "https://localhost:7120/api/skills",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                jQuery.each(data, function (index, itemData) {
                    skillsDb.push({ id: itemData.id, name: itemData.name, value: itemData.skillValue, priority: itemData.priority, deleted: false });
                });
                refreshSkillsDb("d-none");

            }

        });
    }

});