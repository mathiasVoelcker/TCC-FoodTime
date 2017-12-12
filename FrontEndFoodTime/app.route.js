angular.module('app').config(function ($routeProvider) {

  $routeProvider

    //item nº 3.1 e 3.3 - pública
    .when('/home', {
      controller: 'HomeController',
      templateUrl: 'home/home.html'
    })

    //item nº 3.2 - pública
    .when('/login', {
      controller: 'LoginController',
      templateUrl: 'login/login.html'
    })

    // item nº 3.4 e 3.9 - autenticado
    .when('/perfilUsuario', {
      controller: 'PerfilUsuarioController',
      templateUrl: 'usuario/perfil_usuario.html'

    })

    // item nº 3.5, 3.6 e 3.9 - autenticado
    .when('/meusGrupos', {
      controller: 'GrupoController',
      templateUrl: 'grupo/meus_grupos.html'

    })

    // item nº 3.7 -  autenticado
    .when('/informacoesGrupo/:IdGrupo', {
      controller: 'InformacoesGrupoController',
      templateUrl: 'grupo/informacoes_grupo.html'

    })

     // item nº 3.8 - autenticado
     .when('/minhaPreferencia', {
      controller: 'PreferenciaController',
      templateUrl: 'preferencias/minhas_preferencias.html'

    })

    // item nº 3.10 - autenticado
    .when('/sugerirEstabelecimento', {
      controller: 'EstabelecimentoController',
      templateUrl: 'estabelecimento/sugerir_estabelecimento.html'
    })

    // item nº 3.11 - admin
    .when('/aprovacoes', {
      controller: 'EstabelecimentoController',
      templateUrl: 'estabelecimento/aprovacoes.html'

    })
    // item nº 3.12 - pública
    .when('/estabelecimento/:IdEstabelecimento', {
      controller: 'EstabelecimentoController',
      templateUrl: 'estabelecimento/estabelecimento.html'
    })

    // item nº 3.13 - autenticado
    .when('/avaliar/:IdEstabelecimento?', {
      controller: 'AvaliarController',
      templateUrl: 'estabelecimento/avaliar_estabelecimento.html'
    })

    // item nº 3.14 - autenticado
    .when('/notificacoes', {
      controller: 'NotificacoesController',
      templateUrl: 'notificacoes/notificacoes.html'

    })

    // privado
    .when('/privado', {
      controller: 'PrivadoController',
      templateUrl: 'privado/privado.html',
      resolve: {

        // define que para acessar esta página deve ser um usuário autenticado (mas não restringe o tipo de permissão)
        autenticado: function (authService) {
          return authService.isAutenticadoPromise();
        }
      }
    })

    .otherwise('/home');
});
