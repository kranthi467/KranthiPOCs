class Task {
    id: number;
    detail: string;
    completed: boolean;
    checked: boolean;
    constructor(message: string) {
        this.id = _id++;
        this.detail = message;
        this.completed = false;
        this.checked = false;
    }
}

//private element
let taskArray: Task[] = [];
let _id: number = 0;

let title = document.createElement('title');
title.textContent = "ToDo - Java Assignment";
document.head.appendChild(title);

document.body = document.createElement('body');
// text box for input task
let textBoxInput = document.createElement('input');
textBoxInput.setAttribute("type", "text");
document.body.appendChild(textBoxInput);
document.body.appendChild(document.createElement('br'));

var pendingdiv = document.createElement('div');
let completeddiv = document.createElement('div');
//button
let addTask = document.createElement('button');
var errordiv = document.createElement('div');
addTask.textContent = "Add Task";
addTask.onclick = function () {
    if (textBoxInput.value) {
        errordiv.textContent = "";
        console.log(textBoxInput.value);
        let task = new Task(textBoxInput.value);
        taskArray.push(task);
        textBoxInput.value = '';

        let checkBox = document.createElement('input');
        checkBox.setAttribute("type", "checkbox");
        let checkBoxLabel = document.createElement('label');
        checkBoxLabel.textContent = task.detail;
        // checkBox.setAttribute("id", "id_"+(_id-1));

        checkBox.onclick = function () {
            if (task.completed == false) {
                task.completed = true;
                task.checked = true;
                console.log("check me");
                pendingdiv.removeChild(checkBox);
                pendingdiv.removeChild(checkBoxLabel);
                completeddiv.appendChild(checkBox);
                completeddiv.appendChild(checkBoxLabel);
            }
            else {
                if (task.checked == true) {
                    task.checked = false;
                }
                else {
                    task.checked = true;
                }
            }
        }
        pendingdiv.appendChild(checkBox);
        pendingdiv.appendChild(checkBoxLabel);
    }
    else {
        errordiv.textContent = "Enter some name for task";
    }
};
document.body.appendChild(addTask);
document.body.appendChild(errordiv);
//pending heading
let ToDoHeading = document.createElement('h2');
ToDoHeading.textContent = 'Pending';
document.body.appendChild(ToDoHeading);

// pending div tag
document.body.appendChild(pendingdiv);

//Completed heading
let CompleteHeading = document.createElement('h2');
CompleteHeading.textContent = 'Completed';
document.body.appendChild(CompleteHeading);

// completed div tag
document.body.appendChild(completeddiv);

// Delete button
let remove = document.createElement('button');
remove.textContent = "Remove";
remove.onclick = function () {
    let inputs = completeddiv.getElementsByTagName('input');
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
    // let tasks = [];
    // tasks.forEach((task, index) => {
    //     debugger;
    //     if (task.completed && task.checked) {
    //         console.log("removed-->" + task.detail);
    //         tasks.push(index);
    //         //taskArray.splice(index, 1);
    //     }
    // });
    percentageReload();
    taskArray.forEach((task) => {
        console.log(task.detail);
    });
};
document.body.appendChild(remove);

// Percentage heading
let percentageHeading = document.createElement('p');
percentageHeading.textContent = 'Percentage: ';
document.body.appendChild(percentageHeading);

var percentage = document.createElement('text');
percentage.textContent = '0';
document.addEventListener("click", () => { percentageReload(); });

var percentageReload = () => {
    var numerator: number = 0;
    var denominator: number = 0;
    var percent: number = 0;
    taskArray.forEach((task) => {
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