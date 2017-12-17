angular.module('app').run(function ($rootScope){

  $rootScope.formatarPrecoMedio = function(numero){
    numero = numero.toFixed(2);
    return numero.toString().replace(/[.]/, ",")
  }

  $rootScope.getStars = function(rating) {
    // Get the value
    var val = parseFloat(rating);
    // Turn value into number/100
    var size = val*10;
    return size + '%';
  }

})
