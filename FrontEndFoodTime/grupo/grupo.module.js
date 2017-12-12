angular.module('auth').factory('grupoService', function (authConfig, $http, $q, $location, $localStorage, $rootScope) {

  let urlGrupo = authConfig.urlGrupo;

  function criarGrupo(grupo){
    return $http.post(urlGrupo, grupo)
  }

  function buscarGrupoPorUsuario(idUsuario){
    return $http.get(urlGrupo + "buscarPorUsuario?idUsuario=" + idUsuario)
  }

  function buscarGrupo(idGrupo){
    return $http.get(urlGrupo + idGrupo)
  }


  return{
    criarGrupo: criarGrupo,
    buscarGrupoPorUsuario: buscarGrupoPorUsuario,
    buscarGrupo: buscarGrupo
  }
})
