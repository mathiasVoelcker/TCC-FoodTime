angular
.module('app')
.directive('loginDiretiva',function(){

    return{
        scope:{
            p: '=loginDiretiva'
        },
        templateUrl:'login/login.directive.html'
    };
});