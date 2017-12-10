angular.module('app', ['ngRoute', 'auth', 'toastr']);

// Configurações utilizadas pelo módulo de autenticação (authService)
angular.module('app').constant('authConfig', {

    // Obrigatória - URL da API que retorna o usuário

    //urlUsuario: 'http://10.99.0.12:3296/api/acessos/usuarioLogado',
    //urlUsuario: 'http://10.99.0.24/AutDemo.WebApi/api/acessos/usuariologado',

    urlUsuario: 'http://localhost:65510/api/Usuario/',

    urlAvaliacao: 'http://localhost:65510/api/avaliacao/',

    urlAvaliacaoRegistro: 'http://localhost:65510/api/avaliacao/registro/',

    urlEstabelecimento: 'http://localhost:65510/api/estabelecimento/',

    // Obrigatória - URL da aplicação que possui o formulário de login
    urlLogin: '/login',

    // Opcional - URL da aplicação para onde será redirecionado (se for informado) após o LOGIN com sucesso
    urlPrivado: '/privado',

    urlGrupo: '/meusGrupos',

    urlInformacoesGrupo: '/informacoesGrupo',

    urlAvaliarEstab: '/avaliarEstab',

    urlPerfilUsuario: '/perfilUsuario',

    urlMinhaPreferencia: '/minhaPreferencia',

    urlSugerirEstabelecimento: '/sugerirEstabelecimento',

    urlSugerirEstabelecimento: '/aprovacoes',

    urlSugerirEstabelecimento: '/notificacoes',

    // Opcional - URL da aplicação para onde será redirecionado (se for informado) após o LOGOUT
    urlLogout: '/home'
});
