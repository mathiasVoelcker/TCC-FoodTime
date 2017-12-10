angular.module('app').config(function ($routeProvider) {

  $routeProvider

    // pública
    .when('/home', {
      controller: 'HomeController',
      templateUrl: 'home/home.html'
    })

    // pública
    .when('/login', {
      controller: 'LoginController',
      templateUrl: 'login/login.html'
    })

    .when('/estabelecimento', {
      controller: 'EstabelecimentoController',
      templateUrl: 'estabelecimento/estabelecimento.html'
    })

    .when('/avaliar/:IdEstabelecimento?', {
      controller: 'AvaliarController',
      templateUrl: 'estabelecimento/avaliar_estabelecimento.html'
    })

    .when('/sugerirEstabelecimento', {
      controller: 'EstabelecimentoController',
      templateUrl: 'estabelecimento/sugerir_estabelecimento.html'
    })

     // pública
     .when('/perfilUsuario/:IdUsuario?', {
      controller: 'PerfilUsuarioController',
      templateUrl: 'usuario/perfil_usuario.html'

    })

     // pública
     .when('/informacoesGrupo/:IdGrupo?', {
      controller: 'GrupoController',
      templateUrl: 'grupo/informacoes_grupo.html'

    })


     // pública
     .when('/meusGrupos', {
      controller: 'GrupoController',
      templateUrl: 'grupo/meus_grupos.html'

    })

     // pública
     .when('/minhaPreferencia', {
      controller: 'PreferenciaController',
      templateUrl: 'preferencias/minhas_preferencias.html'

    })

     // pública
     .when('/aprovacoes', {
      controller: 'EstabelecimentoController',
      templateUrl: 'estabelecimento/aprovacoes.html'

    })

      // pública
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
