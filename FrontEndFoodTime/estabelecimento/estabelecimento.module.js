angular.module('auth').factory('estabService', function (authConfig, $http, $q, $location, $localStorage, $rootScope) {

  let urlAvaliiacaoRegistro = authConfig.urlAvaliiacaoRegistro;

  function criarAvaliacao(avaliacao){
    return $http.post(urlAvaliiacaoRegistro, avaliacao)
  }

  return{
    criarAvaliacao: criarAvaliacao
  }
})
