selected = 0;

//Option highlighting 
var select_list = document.getElementById('menu');
select_list.onclick = function(event) {
    target = event.target;

    if (target.tagName != 'P') return;
    target.style.backgroundColor = '#74dfff';
    selected = 1;
};

function move_one() {
    //Проверка на нажатие кнопок
    if (selected === 0) {
        alert('Элемент не выбран');
        return;
    }
    if (target.tagName != 'P') return;
    var item = target;
    item.style.backgroundColor = 'transparent';
    parentItemAll.appendChild(item);
    selected = 0;
}

function move_all() {
    for (var i = 0; i = parentItem.childNodes.length; i++) {
        item_all = parentItem.querySelector('p');
        if (item_all === null) {
            return;
        }
        item_all.style.backgroundColor = 'transparent';
        parentItemButton.appendChild(item_all);
    }
}

//Перетаскивание объектов
var buttons = document.getElementById('Buttons');
buttons.onclick = function(event) {
    var target = event.target;
    if (target.tagName != 'BUTTON') return;

    if (target.id === 'button1') {
        parentItem = document.getElementById('ListAvailable');
        parentItemButton = document.getElementById('ListSelected');
        move_all();
    } else if (target.id === 'button2') {
        parentItemAll = document.getElementById('ListSelected');
        move_one();
    } else if (target.id === 'button3') {
        parentItemAll = document.getElementById('ListAvailable');
        move_one();
    } else if (target.id === 'button4') {
        parentItem = document.getElementById('ListSelected');
        parentItemButton = document.getElementById('ListAvailable');
        move_all();
    }
};