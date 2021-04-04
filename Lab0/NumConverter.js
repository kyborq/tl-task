// Решил разделить функции, одна функция для суммы переведенного числа
// а другая для произведения

function convertMul(num, sys) {
  let rem,
    mul = 1;
  if (num >= sys) {
    rem = num % sys;
    num = (num - (num % sys)) / sys;
    mul = convertMul(num, sys);
    return mul * rem;
  } else {
    return num;
  }
}

function convertSum(num, sys) {
  let rem, sum;
  if (num >= sys) {
    rem = num % sys;
    num = (num - (num % sys)) / sys;
    sum = convertSum(num, sys);
    return sum + rem;
  } else {
    return num;
  }
}

function convert(num, sys) {
  return convertMul(num, sys) - convertSum(num, sys);
}

console.log(convert(239, 8));
