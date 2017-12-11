select * from schemaFoodTime.estabelecimento;
select * from schemaFoodTime.preferencia;
select * from schemaFoodTime.usuario;
select * from schemaFoodTime.usuario_preferencia;
select * from schemaFoodTime.estabelecimento_preferencia;
select * from schemaFoodTime.Avaliacao;

insert into schemaFoodTime.usuario_preferencia (id_usuario, id_preferencia)
values (1, 1);
insert into schemaFoodTime.usuario_preferencia (id_usuario, id_preferencia)
values (1, 2)
insert into schemaFoodTime.usuario_preferencia (id_usuario, id_preferencia)
values (2, 3);
insert into schemaFoodTime.usuario_preferencia (id_usuario, id_preferencia)
values (2, 4);
insert into schemaFoodTime.usuario_preferencia (id_usuario, id_preferencia)
values (2, 5);

update schemaFoodTime.avaliacao
set comentario = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'
where id < 12;

insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30, -50.0);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 1.0, 1.0);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 9.0, 9.0);

insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('teste', 'test', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 1.5, 1);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Super Restaurante', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 2);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Super Rest', '9292329832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 21.2, 3);

update schemaFoodTime.estabelecimento
set horarioFechamento = CURRENT_TIMESTAMP
where id < 3;

insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Fratelo', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 1);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Super Restaurante', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 1);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Super Restaurante', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 1);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Super Restaurante', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 1);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Super Restaurante', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 1);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Super Restaurante', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 1);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Super Restaurante', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 1);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Super Restaurante', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 1);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Super Restaurante', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 1);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Super Restaurante', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 1);

insert into schemaFoodTime.usuario (email, senha, nome, sobrenome, dataNascimento, fotoPerfil, admin)
values ('teste', 'test', 'test', 'test', CURRENT_TIMESTAMP, 'test', 1);
insert into schemaFoodTime.usuario (email, senha, nome, sobrenome, dataNascimento, fotoPerfil, admin)
values ('teste1', 'teste1', 'teste1', 'teste1', CURRENT_TIMESTAMP, 'teste1', 0);

insert into schemaFoodTime.usuario (email, senha, nome, sobrenome, dataNascimento, fotoPerfil, admin)
values ('teste2', 'teste1', 'teste1', 'teste1', CURRENT_TIMESTAMP, 'teste1', 0);

update schemaFoodTime.estabelecimento
set id_endereco = 11
where id = 3;

update schemaFoodTime.usuario
set FotoPerfil = ''
where id < 6;


insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30, -51.0);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30.1, -51.1);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30.2, -51.1);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30.0, -51.1);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30.2, -51.0);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30.1, -51.2);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30.0, -51.2);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30.1, -51.15);

select * from schemaFoodTime.categoria;

insert into schemaFoodTime.preferencia
values ('Pizza', 1);
insert into schemaFoodTime.preferencia
values ('Japonesa', 1);
insert into schemaFoodTime.preferencia
values ('Hamburgueria', 1);
insert into schemaFoodTime.preferencia
values ('Saudavel', 1);
insert into schemaFoodTime.preferencia
values ('Fast Food', 1);
insert into schemaFoodTime.preferencia
values ('Trash', 0);


insert into schemaFoodTime.Categoria
values ('Cafe');
insert into schemaFoodTime.Categoria
values ('Vida Noturna');
insert into schemaFoodTime.Categoria
values ('Almoço/Jantar');

update schemaFoodTime.usuario
set email = 'mathias@gmail.com'
where id = 1;

insert into schemaFoodTime.Foto (caminho, Id_Estabelecimzento) 
values('https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Mcdonalds-90s-logo.svg/220px-Mcdonalds-90s-logo.svg.png',1)
insert into schemaFoodTime.Foto (caminho, Id_Estabelecimzento) 
values('https://s3.amazonaws.com/media.cuponeria.com.br/2017/07/cupom-outback-_2421-420x315.jpg',2)
insert into schemaFoodTime.Foto (caminho,Id_Estabelecimzento) 
values('http://pizzariafratello.com.br/wp-content/uploads/2015/09/logo_fratello.png',3)
insert into schemaFoodTime.Foto (caminho, Id_Estabelecimzento) 
values('https://www.temakeriajapesca.com.br/pedidos/image/data/temakeriajapesca-logo.png',4)
insert into schemaFoodTime.Foto (caminho, Id_Estabelecimzento) 
values('http://tibumbr.com.br/storage/empresasgallery/888/1449550011122033488868131746128784723704758n.jpg',5)
insert into schemaFoodTime.Foto (caminho, Id_Estabelecimzento)
values('https://i2.wp.com/www.grubgrade.com/wp-content/uploads/2017/10/02346-01_FarmhouseKing-Homepage-Banner_1800x760-CR.jpg?resize=500%2C418',6)
insert into schemaFoodTime.Foto (caminho, Id_Estabelecimzento) 
values('http://plugcitarios.com/wp-content/uploads/2016/04/Habibs.png',7)
insert into schemaFoodTime.Foto (caminho, Id_Estabelecimzento) 
values('https://coisasqueeugostodotcom1.files.wordpress.com/2013/02/le-grand-burger5.jpg',8)
insert into schemaFoodTime.Foto (caminho, Id_Estabelecimzento)
values('http://peti-app.ddns.net:8070/deliveryWS2/webresources/Delivery/storeimage/1',9)
insert into schemaFoodTime.Foto (caminho, Id_Estabelecimzento) 
values('http://www.sebraemercados.com.br/wp-content/uploads/2017/05/restaurante-sebrae-2-e1494853241838.jpg',10) 

select pref.descricao
from schemaFoodTime.preferencia pref inner JOIN
schemaFoodTime.estabelecimento_preferencia ep 
on pref.id = ep.id_preferencia
where ep.id_estabelecimento = 2;


drop table schemaFoodTime.endereco;
