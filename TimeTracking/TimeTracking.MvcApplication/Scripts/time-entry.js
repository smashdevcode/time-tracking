
$(document).ready(function () {

	var projectTasksJson = JSON.parse($("#ProjectTasksJson").val());
	var selectedProjectId = $("#ProjectId").val();
	var selectedProjectTaskId = $("#ProjectTaskId").val();

	var viewModel = {
		projectTasks: ko.observableArray(projectTasksJson),
		selectedProjectId: ko.observable(selectedProjectId),
		selectedProjectTaskId: ko.observable(selectedProjectTaskId)
	};

	ko.applyBindings(viewModel);

	viewModel.selectedProjectId.subscribe(function (newProjectId) {
		$.getJSON("/TimeEntry/GetProjectTasks", { "id": newProjectId }, function (data) {
			viewModel.projectTasks(data);
		});
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
