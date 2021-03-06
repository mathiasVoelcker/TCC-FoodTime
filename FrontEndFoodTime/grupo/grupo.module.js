angular.module('auth').factory('grupoService', function (authConfig, $http, $q, $location, $localStorage, $rootScope) {

  let urlGrupo = authConfig.urlGrupo;
  let urlGrupoUsuario = authConfig.urlGrupoUsuario;
  let urlEstabelecimento = authConfig.urlEstabelecimento;
  let urlUsuario = authConfig.urlUsuario;

  function criarGrupo(grupo){
    return $http.post(urlGrupo, grupo)
  }

  function buscarGrupoPorUsuario(idUsuario){
    return $http.get(urlGrupo + "buscarPorUsuario?idUsuario=" + idUsuario)
  }

  function buscarGrupo(idGrupo){
    return $http.get(urlGrupo + idGrupo)
  }

  function buscarRecomendacao(idUsuario, idGrupo, latitude, longitude){
    return $http.get(urlEstabelecimento + "recomendacaoGrupo?idUsuario=" + idUsuario +  "&idGrupo=" + idGrupo + "&latitude=" + latitude + "&longitude=" + longitude)
  }

  function atualizarGrupo(novosParticipantes){
    return $http.post(urlGrupoUsuario, novosParticipantes)
  }

  return{
    criarGrupo: criarGrupo,
    buscarGrupoPorUsuario: buscarGrupoPorUsuario,
    buscarGrupo: buscarGrupo,
    buscarRecomendacao: buscarRecomendacao,
    atualizarGrupo: atualizarGrupo
  }
})
