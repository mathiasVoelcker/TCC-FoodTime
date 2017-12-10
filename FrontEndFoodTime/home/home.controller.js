angular.module('app').controller('HomeController', function ($scope, authService, $http, estabService) {
    
  $scope.usuarioLogado = authService.getUsuario();

  estabService.listar();

    estabService.listar().then(
      function(response){
       
        $scope.estabelecimentos = response.data;
        if(response.data.Fotos[0].Caminho==undefined)
          $scope.estabelecimentos.foto = "\auxiliares\imgs\logoFoodTime_new.jpg"
        else        
          $scope.estabelecimentos.foto = response.data.Fotos[0].Caminho;
        // "c:\Users\Usuario\Documents\DEV\vitor.ramos\TCC\TCC-FoodTime\FrontEndFoodTime\auxiliares\imgs\logoFoodTime_new.jpg"
      }
    );
    
  });
