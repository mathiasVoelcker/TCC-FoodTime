// Cria módulo
angular.module('auth', ['ngStorage']);

// Adiciona header de autenticação, se existir
angular.module('auth').config(function ($httpProvider) {
  let headerAuth = JSON.parse(window.localStorage.getItem('ngStorage-headerAuth'));
  if (headerAuth) {
    $httpProvider.defaults.headers.common.Authorization = headerAuth;
  }
});

// Service de autenticação
angular.module('auth').factory('authService', function (authConfig, $http, $q, $location, $localStorage, $rootScope) {

  // Utiliza constant de configuração
  let urlUsuario = authConfig.urlUsuarioLogado;
  let urlLogin = authConfig.urlLogin;
  let urlPrivado = authConfig.urlPrivado;
  let urlLogout = authConfig.urlLogout;


  // LOGIN - Retorna PROMISE com o response (sucesso ou erro)
  function login(usuario) {

    let deferred = $q.defer();

    let headerAuth = montarHeader(usuario);

    $http({
      url: urlUsuario,
      method: 'GET',
      headers: headerAuth
    }).then(

      // Sucesso - HTTP 200
      function (response) {
        // Adiciona usuário e header ao localstorage
        var usuario = response.data.dados
        usuario.DataNascimento = formatarData(usuario.DataNascimento)
        $localStorage.usuarioLogado = usuario;
        $localStorage.headerAuth = montarHeader(usuario)['Authorization'];

        // Adiciona header de autenticação em todos os próximos requests
        $http.defaults.headers.common.Authorization = $localStorage.headerAuth;

        $rootScope.$broadcast('authLoginSuccess');

        // Redireciona se tiver uma url configurada
        if (urlPrivado) {
          $location.path(urlPrivado);
        }

        // resolve promise com sucesso
        deferred.resolve(response);
      },

      // Erro
      function (response) {
        // resolve promise com erro
        deferred.reject(response);
      });

    // Retorna promise, sem resolver
    return deferred.promise;
  };



  // LOGOUT (sem retorno)
  function logout() {
    // Limpa localstorage e http headers adicionados
    delete $localStorage.usuarioLogado;
    delete $localStorage.headerAuth;
    $http.defaults.headers.common.Authorization = undefined;

    $rootScope.$broadcast('authLogoutSuccess');

    // Redireciona se tiver uma url configurada
    if (urlLogout) {
      $location.path(urlLogout);
    }
  };

  function getUsuario() {
    return $localStorage.usuarioLogado;
  };

  function isAutenticado() {
    return !!getUsuario();
  };

  function possuiPermissao(permissao) {
    return isAutenticado() &&
     // getUsuario().Permissoes.find((p) => p.Nome === permissao);
     getUsuario().Administrador == permissao;
  };


  // PROMISE

  function isAutenticadoPromise() {

    let deferred = $q.defer();

    if (isAutenticado()) {
      deferred.resolve();

    } else {
      $location.path(urlLogin);
      deferred.reject();
    }

    return deferred.promise;
  };

  function possuiPermissaoPromise(permissao) {

    let deferred = $q.defer();

    if (possuiPermissao(permissao)) {
      deferred.resolve();

    } else {
      deferred.reject();
    }

    return deferred.promise;
  };

  function montarHeader(usuario) {
    let hash = window.btoa(`${usuario.email}:${usuario.senha}`);
    return {
      'Authorization': `Basic ${hash}`
    };
  };

  function formatarData(data) {
    data = data.substring(0, 10)
    var dataArray = data.split("-")
    var retorno = dataArray[2] + "/" + dataArray[1] + "/" + dataArray[0]
    return retorno
  }

  return {
    login: login,
    logout: logout,
    getUsuario: getUsuario,
    possuiPermissao: possuiPermissao,
    isAutenticado: isAutenticado,
    isAutenticadoPromise: isAutenticadoPromise,
    possuiPermissaoPromise: possuiPermissaoPromise
  };
});
