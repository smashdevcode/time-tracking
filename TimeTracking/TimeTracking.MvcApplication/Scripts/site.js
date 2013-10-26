
function ProjectTasksViewModel() {
	this.projectTasks = ko.observableArray([]);
	this.selectedProjectTaskId = ko.observable(null);
}

function GetProjectTasks() {
	var projectId = $("#ProjectId").val();
	$.getJSON("/TimeEntry/GetProjectTasks/" + projectId, null, function (data) {
		projectTasksVM.projectTasks(data);
	});
}

$(document).ready(function () {
	GetProjectTasks();
});

var projectTasksVM = new ProjectTasksViewModel();
ko.applyBindings(projectTasksVM);
