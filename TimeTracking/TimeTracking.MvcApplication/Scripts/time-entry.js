
$(document).ready(function () {

	var projectTasksJson = JSON.parse($("#ProjectTasksJson").val());
	var selectedProjectId = $("#ProjectId").val();
	var selectedProjectTaskId = $("#ProjectTaskId").val();
	var isBillable = $("#Billable").is(":checked");

	var viewModel = {

		projectTasks: ko.observableArray(projectTasksJson),
		selectedProjectId: ko.observable(selectedProjectId),
		selectedProjectTaskId: ko.observable(selectedProjectTaskId),
		isBillable: ko.observable(isBillable),

		isProjectTaskIdBillable: function (projectTaskId) {
			var isBillable = false;
			var projectTask = null;
			var projectTasks = viewModel.projectTasks();

			for (var i = 0; i < projectTasks.length; i++) {
				if (projectTasks[i].ProjectTaskId == projectTaskId) {
					projectTask = projectTasks[i];
					break;
				}
			}

			if (projectTask != null) {
				isBillable = projectTask.Billable;
			}

			return isBillable;
		}

	};

	ko.applyBindings(viewModel);

	viewModel.selectedProjectId.subscribe(function (newProjectId) {
		$.getJSON("/TimeEntry/GetProjectTasks", { "id": newProjectId }, function (data) {
			viewModel.projectTasks(data);
		});
	});

	viewModel.selectedProjectTaskId.subscribe(function (newProjectTaskId) {
		var isBillable = viewModel.isProjectTaskIdBillable(newProjectTaskId);
		viewModel.isBillable(isBillable);
	});

	var mode = $("#Mode").val();
	if (mode === "Edit") {
		$("#DeleteTimeEntry").click(function () {
			if (confirm("Are you sure you want to delete this time entry?")) {
				$("#DeleteTimeEntryForm").submit();
			}
		});
	}

});
