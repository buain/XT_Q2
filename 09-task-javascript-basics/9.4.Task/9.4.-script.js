var url, ViewTime, TimeOutID, _progress, _button, pause=false;

function NextPage(address){
    location.assign(address);
}

function Pause(addr){
    if(!pause){
		pause = true;
		_button = document.getElementById("pause");
		_button.innerHTML = "Продолжить";
		clearTimeout(TimeOutID);
	}
	else{
		pause = false;
		_button = document.getElementById("pause");
		_button.innerHTML = "Стоп";
		Progress(addr, ViewTime);
	}
}
function Progress(addr, _time){
	var a = "" + addr,b,bar;
	
    if(a.match(/.+\.html/)){
		url = "" + a;
	}
	b = +_time;
	
	if(ViewTime === undefined){
		ViewTime = +b;
	}
	bar = document.getElementById("LeftTime");
	bar.innerHTML = ViewTime;
	ViewTime--;
	
	if(ViewTime > 0){
		TimeOutID = setTimeout(Progress, 1000);
	}
	else{
		NextPage(url);
	}
}

function Stop(){
	clearTimeout(TimeOutID);
    ViewTime = undefined;
}

function Exit(){
    window.top.close();
}
