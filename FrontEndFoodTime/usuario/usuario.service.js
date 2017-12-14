angular.module('auth').factory('usuarioService', function($http, authConfig){


  let urlUsuario = authConfig.urlUsuario;
  let urlAvaliacao = authConfig.urlAvaliacao;
  let urlEstabelecimento = authConfig.urlEstabelecimento;
  let urlNotificacao = authConfig.urlNotificacao;
  let urlGrupoUsuario = authConfig.urlGrupoUsuario;

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
    return $http.get(urlAvaliacao + "buscarPorIdUsuario?idUsuario=" + id)
  }

  function buscarRecomendacao(idUsuario, latitude, longitude){
    return $http.get(urlEstabelecimento + "recomendacao?idUsuario=" + idUsuario +  "&latitude=" + latitude + "&longitude=" + longitude)
  }

  function excluirRecomendacao(idEstabelecimento, idUsuario){
    return $http.put(urlUsuario + "excluirRecomendacao?idEstabelecimento=" + idEstabelecimento + "&idUsuario=" + idUsuario)
  }

  function buscarPorFiltro(filtro){
    return $http.get(urlUsuario + "/buscarPorFiltro?filtro=" + filtro)
  }

  function buscarPorGrupo(idGrupo, filtro){
    return $http.get(urlUsuario + "buscarPorGrupo?idGrupo=" + idGrupo + "&filtro=" + filtro)
  }

  function buscarSolicitacoesGrupo(idUsuario){
    return $http.get(urlNotificacao + "solicitacoes?idUsuario=" + idUsuario)
  }

  function aprovarSolicitacao(idGrupo, idUsuario){
    return $http.put(urlGrupoUsuario + "AprovarSolicitacao?idGrupo=" + idGrupo + "&idUsuario=" + idUsuario)
  }

  function adicionarPreferencias(idPreferencias, idUsuario){
    debugger
    return $http.put(urlUsuario + "adicionarPreferencias?&idUsuario=" + idUsuario, idPreferencias)
  }

  return {
    listar: listar,
    buscarUsuario: buscarUsuario,
    addUsuario: addUsuario,
    removeUsuario: removeUsuario,
    alterUsuario: alterUsuario,
    buscarAvaliacoesUsuario: buscarAvaliacoesUsuario,
    buscarRecomendacao: buscarRecomendacao,
    excluirRecomendacao: excluirRecomendacao,
    buscarPorFiltro: buscarPorFiltro,
    buscarPorGrupo: buscarPorGrupo,
    buscarSolicitacoesGrupo: buscarSolicitacoesGrupo,
    aprovarSolicitacao: aprovarSolicitacao,
    adicionarPreferencias: adicionarPreferencias
  }
})
