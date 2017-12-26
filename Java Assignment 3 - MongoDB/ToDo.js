var Task = (function () {
    function Task(name, status, tags) {
        this.detail = name;
        this.status = status;
        this.tags = tags;
    }
    return Task;
}());

var taskArray = [];
var _tags = [];
var _editMode = { isEdit: false, task: {} };

document.onreadystatechange = function () {
    showpending = document.getElementById('showpending');
    tbody = document.getElementById('displaybody');
    tagElement = document.getElementById('tags');
    tagsDisplay = document.getElementById('tagdisplay');
    taskNameInput = document.getElementById('taskname');
    statusInput = document.getElementById('status');
    errorTag = document.getElementById("errors");
    search = document.getElementById("search");
}

var addTag = function () {
    var tag = tagElement.value;
    if (canAddTag(tag)) {
        _tags.push(tag);
        var tagX = document.createElement('a');
        tagX.setAttribute("class", "mr-1 ml-1");
        tagX.setAttribute("href", "#");
        tagX.textContent = 'X';
        var tagLabel = document.createElement("label");
        tagLabel.textContent = tag + " ";
        tagsDisplay.appendChild(tagLabel);
        tagsDisplay.appendChild(tagX);
        tagX.onclick = function () {
            removeTag(tag);
            tagsDisplay.removeChild(tagLabel);
            tagsDisplay.removeChild(tagX);
        }
        tagElement.value = "";
    }
}

var removeTag = function (tag) {
    _tags.forEach((value, index) => {
        if (value == tag) {
            _tags.splice(index, 1);
        }
    });
}

var removeTags = function () {
    _tags = [];
    tagElement.value = "";
    removeAllChildNodes(tagsDisplay);
}

var removeAllChildNodes = function (_Node) {
    for (var i = _Node.childNodes.length - 1; i >= 0; i--) {
        _Node.removeChild(_Node.firstChild);
    }
}

var canAddTag = function (p_tag) {
    var retVal = true;
    if (_tags.length >= 3) {
        errorTag.textContent = "Cannot add more than 3 tags";
        retVal = false;
    }
    else if (p_tag == "") {
        errorTag.textContent = "Empty tags are not allowed";
        retVal = false;
    }
    else {
        _tags.forEach((tag) => {
            if (tag == p_tag) {
                errorTag.textContent = "Tag already added";
                retVal = false;
            }
        });
    }

    if (retVal) {
        errorTag.textContent = "";
    }
    return retVal;
}

var addTask = function () {
    if (taskNameInput.value) {
        if (_editMode.isEdit) {
            task = _editMode.task;
            task.detail = taskNameInput.value;
            task.status = statusInput.value;
            task.tags = _tags;
            DoActionMongo(Action.Put, task)
                .then(() => {
                    addTaskToList(task);
                    percentageReload();
                });
            _editMode.isEdit = false;
        }
        else {
            task = new Task(taskNameInput.value, statusInput.value, _tags);
            DoActionMongo(Action.Post, task)
                .then(task => {
                    taskArray.push(task);
                    addTaskToList(task);
                    percentageReload();
                });
        }
        taskNameInput.value = "";
        statusInput.value = 1;
        removeTags();
        errorTag.textContent = "";

        percentageReload();
    }
    else {
        errorTag.textContent = "Enter some name for task";
    }
};

var editModeStart = function (task) {
    _editMode.isEdit = true;
    _editMode.task = task;
    taskNameInput.value = task.detail;
    statusInput.value = task.status;
    task.tags.forEach((tag) => {
        tagElement.value = tag;
        addTag();
    });
    tagElement.value = "";
};

var addTaskToList = function (task) {
    if (trow = document.getElementById("trow" + task._id)) {
        removeAllChildNodes(trow);
    }
    else {
        trow = document.createElement('tr');
        trow.setAttribute("id", "trow" + task._id);

        tbody.appendChild(trow);
    }

    var tdataCompleted = document.createElement('td');
    var completed = document.createElement('input');
    completed.setAttribute("type", "checkbox");
    tdataCompleted.appendChild(completed);
    trow.appendChild(tdataCompleted);

    var tdataTaskName = document.createElement('td');
    tdataTaskName.textContent = task.detail;
    trow.appendChild(tdataTaskName);

    var tdataTags = document.createElement('td');
    tdataTags.textContent = task.tags.join(', ');
    trow.appendChild(tdataTags);

    var tdataStatus = document.createElement('td');
    if (task.status == 1) {
        tdataStatus.textContent = "Pending";
    }
    else {
        completed.checked = true;
        tdataStatus.textContent = "Completed";
    }
    trow.appendChild(tdataStatus);

    var tdataActions = document.createElement('td');
    var editButton = document.createElement('button');
    editButton.setAttribute("class", "btn btn-primary p-1");
    editButton.textContent = "Edit";
    editButton.onclick = function () {
        editModeStart(task);
    };
    tdataActions.appendChild(editButton);
    var deleteButton = document.createElement('button');
    deleteButton.setAttribute("class", "btn btn-danger p-1");
    deleteButton.textContent = "Delete";
    deleteButton.onclick = function () {
        removeTaskByID(task._id);
    };
    tdataActions.appendChild(deleteButton);
    trow.appendChild(tdataActions);

    completed.onclick = function () {
        if (task.status == 1) {
            task.status = 2;
            tdataStatus.textContent = "Completed";
        }
        else {
            task.status = 1;
            tdataStatus.textContent = "Pending";
        }
        DoActionMongo(Action.Put, task)
            .then(() => {
                addTaskToList(task);
                percentageReload();
            });
    };
};

var percentageReload = function () {
    var numerator = 0;
    var denominator = 0;
    var percent = 0;
    taskArray.forEach(function (task) {
        denominator++;
        if (task.status == 2) {
            numerator++;
        }
    });
    percent = (numerator / denominator) * 100;
    var progress = document.getElementById("progress").getElementsByTagName("td");
    progress[1].textContent = denominator - numerator;
    progress[3].textContent = numerator;
    progress[5].textContent = isNaN(percent) ? '0%' : percent.toFixed(2) + "%";
    hidePendingAndSearch();
};

var hidePendingAndSearch = function () {
    var trows = tbody.getElementsByTagName('tr');
    for (var i = 0; i < trows.length; i++) {
        var checkbox = trows[i].getElementsByTagName('input');
        var taskname = trows[i].getElementsByTagName('td')[1].textContent;
        var searched = (taskname.indexOf(search.value) > -1);
        var showAndChecked = (showpending.checked && checkbox[0].checked);
        if (!showAndChecked && searched) {
            trows[i].removeAttribute('hidden');
        }
        else if (showAndChecked || !searched) {
            trows[i].setAttribute('hidden', 'hidden');
        }
    }
};

var deleteCompleted = function () {
    for (var i = taskArray.length - 1; i >= 0; i--) {
        if (taskArray[i].status == 2) {
            removeTask(i);
        }
    }
}

var removeTaskByID = function (id) {
    for (var i = taskArray.length - 1; i >= 0; i--) {
        if (taskArray[i]._id == id) {
            removeTask(i);
        }
    }
}

var removeTask = function (index) {
    var trow = document.getElementById('trow' + taskArray[index]._id);
    if (trow) {
        trow.remove();
    }
    if (index != null) {
        DoActionMongo(Action.Delete, taskArray[index]);
        taskArray.splice(index, 1);
    }
    percentageReload();
};


var MongoClient = require('mongodb').MongoClient
    , co = require('co')
    , assert = require('assert');

var ObjectId = require('mongodb').ObjectID;

var url = 'mongodb://localhost/test';

const Action = {
    Post: "POST",
    Put: "PUT",
    Get: "GET",
    Delete: "DELETE"
}

function DoActionMongo(method, data) {
    co(function* () {
        const db = yield MongoClient.connect(url);
        console.log("Connected successfully to server");
        switch (method) {
            case Action.Post:
                return new Promise(
                    function (resolve) {
                        var results = yield db.collection('tasks')
                            .insert(data);
                        resolve(results);
                    });
                break;
            case Action.Put:
                return new Promise(
                    function (resolve) {
                        var results = yield db.collection('tasks')
                            .update({ "_id": ObjectId(data._id) }, data);
                        resolve(results);
                    });
                break;
            case Action.Delete:
                yield db.collection('tasks')
                    .deleteOne({ "_id": ObjectId(data._id) });
                break;
            case Action.Get:
                return new Promise(
                    function (resolve) {
                        var results = yield collection.find({}).toArray();
                        resolve(results);
                    });
                break;
        }
        db.close();
        console.log("Server Closed");
    }).catch(err => console.log(err));
}

document.addEventListener("DOMContentLoaded", function () {
    DoActionMongo(Action.Get)
        .then(tempArray => {
            tempArray.forEach((tempTask) => {
                taskArray.push(tempTask);
                addTaskToList(tempTask);
            });
            percentageReload();
        });
});