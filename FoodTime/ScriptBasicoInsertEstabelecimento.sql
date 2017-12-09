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
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 5.0, 5.0);
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

select pref.descricao
from schemaFoodTime.preferencia pref inner JOIN
schemaFoodTime.estabelecimento_preferencia ep 
on pref.id = ep.id_preferencia
where ep.id_estabelecimento = 2;


drop table schemaFoodTime.endereco;
