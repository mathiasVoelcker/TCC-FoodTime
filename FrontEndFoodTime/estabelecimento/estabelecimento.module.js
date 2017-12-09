angular.module('estab', ['ngStorage']);

// Adiciona header de autenticação, se existir
angular.module('estab').config(function ($httpProvider) {
  let headerAuth = JSON.parse(window.localStorage.getItem('ngStorage-headerAuth'));
  if (headerAuth) {
    $httpProvider.defaults.headers.common.Authorization = headerAuth;
  }
});

// Service de autenticação
angular.module('auth').factory('estabService', function (authConfig, $http, $q, $location, $localStorage, $rootScope) {

  let urlAvaliiacaoRegistro = authConfig.urlAvaliiacaoRegistro;


  function criarAvaliacao(avaliacao){
    return $http.post(urlAvaliiacaoRegistro, avaliacao)
  }

  return{
    criarAvaliacao: criarAvaliacao
  }
})
