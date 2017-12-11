angular.module('app')
  .directive('cwiHeader', function (authService, $rootScope) {
      return {
        restrict: 'E',
        scope: {},
        templateUrl: '../home/header.directive.html'
      }

  });


  