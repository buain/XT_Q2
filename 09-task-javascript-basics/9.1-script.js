var input = prompt("Введите предложение:", "Например, у попа была собака");
/*var input = "у попа была собака";*/
var ignore = ["?", "!", ":", ";", ",", ".", " ", "\t", "\r"];
var chars = {}, result;
var arrs = input.split(' ');

arrs.forEach(function(arr){
	arr.split('').forEach(function(one_char, i){
		if(!chars[one_char] && ignore.indexOf(one_char) == -1 && -1 !=arr.indexOf(one_char, i + 1)){
			chars[one_char] = 1;
		}
	});
});

result = input.split('').filter(function(s){
								return !chars[s];
								}).join('');
document.writeln("Исходный текст: ", input)
document.writeln("Результат: ", result);

		