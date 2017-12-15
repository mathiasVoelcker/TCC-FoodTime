angular.module('app', ['ngRoute', 'auth', 'toastr']);

// Configurações utilizadas pelo módulo de autenticação (authService)
angular.module('app').constant('authConfig', {

    // Obrigatória - URL da API que retorna o usuário

    //urlUsuario: 'http://10.99.0.12:3296/api/acessos/usuarioLogado',
    //urlUsuario: 'http://10.99.0.24/AutDemo.WebApi/api/acessos/usuariologado',

    urlUsuario: 'http://localhost:65510/api/Usuario/',

    urlUsuarioLogado: 'http://localhost:65510/api/usuario/usuariologado',

    //autenticado - admin
    urlAvaliacao: 'http://localhost:65510/api/avaliacao/',

    //autenticado - admin
    urlAvaliacaoRegistro: 'http://localhost:65510/api/avaliacao/registro/',

    //pública
    urlEstabelecimento: 'http://localhost:65510/api/estabelecimento/',

    //pública
    urlEstabelecimentoPreferencia: 'http://localhost:65510/api/estabelecimentoPreferencia/',

    //pública
    urlCategoria: 'http://localhost:65510/api/categoria/',

    //autenticado - admin
    urlGrupo: 'http://localhost:65510/api/grupo/',

    urlPreferencia: 'http://localhost:65510/api/preferencia/',
    urlGrupoUsuario: 'http://localhost:65510/api/GrupoUsuario/',

    urlNotificacao: 'http://localhost:65510/api/notificacao/',
    // Obrigatória - URL da aplicação que possui o formulário de login - pública - autenticado e admin
    urlLogin: '/login',

    // Opcional - URL da aplicação para onde será redirecionado (se for informado) após o LOGIN com sucesso
    urlPrivado: '/privado',

    // Opcional - URL da aplicação para onde será redirecionado (se for informado) após o LOGOUT
    //pública - autenticado e admin
    urlLogout: '/home'
});
