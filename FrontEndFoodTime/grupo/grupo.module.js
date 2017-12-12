angular.module('auth').factory('grupoService', function (authConfig, $http, $q, $location, $localStorage, $rootScope) {

  let urlGrupo = authConfig.urlGrupo;

  function criarGrupo(grupo){
    return $http.post(urlGrupo, grupo)
  }

  function buscarGrupo(idUsuario){
    return $http.get(urlGrupo + "buscarPorUsuario?idUsuario=" + idUsuario)
  }


  return{
    criarGrupo: criarGrupo,
    buscarGrupo: buscarGrupo
  }
})
