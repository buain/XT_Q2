var input = prompt("Введите арифметическое выражение:", "Например, 3.5 +4*10-5.3 /5 =");

MathCalculate = function(){
	
	var result = 0,
		strArr = [],
		MathAction = /\-?\d+(\.\d+)?|[\+,\-,\*,\/,\=]{1}/ig;
	
	strArr = input.match(MathAction);
	if(strArr[0]*1+"" !== "NaN"){
		result += strArr[0]*1;
	}
	
	for(var i=0; i < strArr.length; i++){
		switch(strArr[i]){
			case "+": result += strArr[i+1]*1;
				break;
			case "-": result -= strArr[i+1]*1;
				break;
			case "*": result *= strArr[i+1]*1;
				break;
			case "/": result /= strArr[i+1]*1;
				break;
			case "=";
				break;
			default: continue;
				break;
		}
	}

	document.writeln(result);
}
