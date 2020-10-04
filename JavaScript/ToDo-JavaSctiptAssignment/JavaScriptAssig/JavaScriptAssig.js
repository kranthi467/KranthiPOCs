var Task = (function () {
    function Task(message) {
        this.id = _id++;
        this.detail = message;
        this.completed = false;
        this.checked = false;
    }
    return Task;
}());

//private element
var taskArray = [];
var _id = 0;

// title
var title = document.createElement('title');
title.textContent = "ToDo - Java Assignment";
document.head.appendChild(title);
// body
document.body = document.createElement('body');

// text box for input task
var textBoxInput = document.createElement('input');
textBoxInput.setAttribute("type", "text");
document.body.appendChild(textBoxInput);
document.body.appendChild(document.createElement('br'));
var pendingdiv = document.createElement('div');
var completeddiv = document.createElement('div');

//button
var addTask = document.createElement('button');
var errordiv = document.createElement('div');
addTask.textContent = "Add Task";
addTask.onclick = function () {
    if (textBoxInput.value) {
        errordiv.textContent = "";
        console.log(textBoxInput.value);
        var task_1 = new Task(textBoxInput.value);
        taskArray.push(task_1);
        textBoxInput.value = '';
        var checkBox_1 = document.createElement('input');
        checkBox_1.setAttribute("type", "checkbox");
        var checkBoxLabel_1 = document.createElement('label');
        checkBoxLabel_1.textContent = task_1.detail;
        checkBox_1.onclick = function () {
            if (task_1.completed == false) {
                task_1.completed = true;
                task_1.checked = true;
                console.log("check me");
                pendingdiv.removeChild(checkBox_1);
                pendingdiv.removeChild(checkBoxLabel_1);
                completeddiv.appendChild(checkBox_1);
                completeddiv.appendChild(checkBoxLabel_1);
            }
            else {
                if (task_1.checked == true) {
                    task_1.checked = false;
                }
                else {
                    task_1.checked = true;
                }
            }
        };
        pendingdiv.appendChild(checkBox_1);
        pendingdiv.appendChild(checkBoxLabel_1);
    }
    else {
        errordiv.textContent = "Enter some name for task";
    }
};
document.body.appendChild(addTask);
document.body.appendChild(errordiv);

//pending heading
var ToDoHeading = document.createElement('h2');
ToDoHeading.textContent = 'Pending';
document.body.appendChild(ToDoHeading);

// pending div tag
document.body.appendChild(pendingdiv);

//Completed heading
var CompleteHeading = document.createElement('h2');
CompleteHeading.textContent = 'Completed';
document.body.appendChild(CompleteHeading);

// completed div tag
document.body.appendChild(completeddiv);

// Delete button
var remove = document.createElement('button');
remove.textContent = "Remove";
remove.onclick = function () {
    var inputs = completeddiv.getElementsByTagName('input');
    for (var i = inputs.length - 1; i >= 0; i--) {
        if (inputs[i].type.toLowerCase() == 'checkbox' && inputs[i].checked) {
            inputs[i].nextElementSibling.remove();
            inputs[i].remove();
        }
    }
    for (var i = taskArray.length - 1; i >= 0; i--) {
        if (taskArray[i].completed && taskArray[i].checked) {
            console.log("removed-->" + taskArray[i].detail);
            taskArray.splice(i, 1);
        }
    }
    percentageReload();
    taskArray.forEach(function (task) {
        console.log(task.detail);
    });
};
document.body.appendChild(remove);

// Percentage heading
var percentageHeading = document.createElement('p');
percentageHeading.textContent = 'Percentage: ';
document.body.appendChild(percentageHeading);

// percent
var percentage = document.createElement('text');
percentage.textContent = '0';
document.addEventListener("click", function () { percentageReload(); });
var percentageReload = function () {
    var numerator = 0;
    var denominator = 0;
    var percent = 0;
    taskArray.forEach(function (task) {
        denominator++;
        if (task.completed) {
            numerator++;
        }
    });
    console.log(denominator + '....' + numerator);
    percent = (numerator / denominator) * 100;
    percentage.textContent = isNaN(percent) ? '0' : percent.toString();
    numerator = 0;
    denominator = 0;
};
percentageHeading.appendChild(percentage);
