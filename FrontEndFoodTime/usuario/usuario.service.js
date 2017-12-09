angular.module('app').factory('usuarioService', function($http){
    
        
    function listar(){
        let result =  $http.get('http://localhost:8080/usuario/lista');
        debugger
        return result;
    }
    
    function getUsuario(id){
        debugger
        return $http.get('http://localhost:8080/usuario/' + id);
    }
    
    function addUsuario(usuario){
        debugger;
        return $http.post('http://localhost:8080/usuario/novoUsuario', usuario);
    }
    
    function removeUsuario(id){
        return $http.delete('http://localhost:8080/api/usuario/' + id);
    }
    
    function alterUsuario(usuario){
        return $http.put('http://localhost:8080/api/usuario/' + usuario.IdUsuario, usuario)
    }
    
    return {
        listar: listar,
        getUsuario: getUsuario,
        addUsuario: addUsuario,
        removeUsuario: removeUsuario,
        alterUsuario: alterUsuario
    };
})
