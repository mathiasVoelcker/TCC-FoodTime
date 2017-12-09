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

    .when('/avaliar', {
      controller: 'AvaliarController',
      templateUrl: 'estabelecimento/avaliar_estabelecimento.html'
    })


     // pública
     .when('/perfilUsuario', {
      controller: 'PerfilUsuarioController',
      templateUrl: 'usuario/perfil_usuario.html'

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
