angular.module('auth').factory('usuarioService', function($http, authConfig){


  let urlUsuario = authConfig.urlUsuario;
  let urlAvaliiacao = authConfig.urlAvaliiacao;
  let urlEstabelecimento = authConfig.urlEstabelecimento;

  function listar(){
    let result =  $http.get(urlUsuario + lista);
    return result;
  }

  function buscarUsuario(id){
    return $http.get(urlUsuario + id);
  }

  function addUsuario(usuario){
    return $http.post(urlUsuario + novoUsuario, usuario);
  }

  function removeUsuario(id){
    return $http.delete(urlUsuario + id);
  }

  function alterUsuario(usuario){
    return $http.put(urlUsuario + usuario.IdUsuario, usuario)
  }

  function buscarAvaliacoesUsuario(id){
    return $http.get(urlAvaliiacao + "buscarPorIdUsuario?idUsuario=" + 2)
  }

  return {
    listar: listar,
    buscarUsuario: buscarUsuario,
    addUsuario: addUsuario,
    removeUsuario: removeUsuario,
    alterUsuario: alterUsuario,
    buscarAvaliacoesUsuario: buscarAvaliacoesUsuario
  };
})
