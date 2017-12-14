angular.module('auth').factory('estabService', function (authConfig, $http, $q, $location, $localStorage, $rootScope) {

  let urlAvaliacao = authConfig.urlAvaliacao;
  let urlAvaliacaoRegistro = authConfig.urlAvaliacaoRegistro;
  let urlEstabelecimento = authConfig.urlEstabelecimento;
  let urlEstabelecimentoPreferencia = authConfig.urlEstabelecimentoPreferencia;

  function criarAvaliacao(avaliacao){
    return $http.post(urlAvaliacaoRegistro, avaliacao)
  }

  function criarEstabelecimento(estabelecimento){
    return $http.post(urlEstabelecimento, estabelecimento)
  }


  function listar(){
    let result =  $http.get(urlEstabelecimento+"listar");
    return result;
  }
  function listarMapa(){
    let result =  $http.get(urlEstabelecimento+"listarMapa");
    return result;
  }

  function listarCinco(){
    let result =  $http.get(urlEstabelecimento+"listarCinco");
    return result;
  }

  function buscarPorFiltros(filtro){
    let result =  $http.get(urlEstabelecimento+"buscarPorFiltros?estabFiltro.endereco=" + filtro.Endereco + "&estabFiltro.nome=" + filtro.Nome + "&estabFiltro.categorias=" + filtro.Categoria);
    return result;
  }

  function buscarEstabelecimentoPorId(id){
    return $http.get(urlEstabelecimento + id)
  }

  function buscarAvaliacoesEstab(id){
    return $http.get(urlAvaliacao + "buscarPorIdEstabelecimento?idEstab=" + id)
  }

  function buscarPorFiltrosLocalizacao(filtro, posicao){
    return $http.get(urlEstabelecimento+"buscarPorFiltrosLocalizacao?&estabFiltro.nome=" + filtro.Nome + "&estabLocalFiltro.latitude=" + posicao.lat + "&estabLocalFiltro.longitude=" + posicao.lng + "&estabFiltro.categorias=" + filtro.Categoria);
  }

  function adicionarPreferencias(idPreferencias, idEstab){
    return $http.post(urlEstabelecimentoPreferencia + "?idEstabelecimento=" + idEstab, idPreferencias)
  }



  return{
    criarAvaliacao: criarAvaliacao,
    listar: listar,
    listarMapa: listarMapa,
    listarCinco: listarCinco,
    buscarPorFiltros: buscarPorFiltros,
    buscarEstabelecimentoPorId: buscarEstabelecimentoPorId,
    buscarAvaliacoesEstab: buscarAvaliacoesEstab,
    buscarPorFiltrosLocalizacao: buscarPorFiltrosLocalizacao,
    criarEstabelecimento: criarEstabelecimento,
    adicionarPreferencias: adicionarPreferencias
  }


})
