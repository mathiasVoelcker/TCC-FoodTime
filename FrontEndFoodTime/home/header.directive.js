angular
.module('app')
.directive('headerDiretiva',function(){

    return{
        scope:{
            p: '=headerDirective'
        },
        templateUrl:'home/header.directive.html'
    };
});