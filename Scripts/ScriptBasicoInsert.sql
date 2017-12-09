select * from schemaFoodTime.estabelecimento;
select * from schemaFoodTime.preferencia;
select * from schemaFoodTime.usuario;
select * from schemaFoodTime.usuario_preferencia;
select * from schemaFoodTime.estabelecimento_preferencia;
select * from schemaFoodTime.Avaliacao;
select * from schemaFoodTime.endereco

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
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30.12612436, -51.00952148);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -32.12612436, -50.00952148);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -31.12612436, -51.00952148);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30.52612436, -50.10952148);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30.32612436, -51.20952148);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30.52612436, -51.00952148);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', -30.12612436, -51.90952148);

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
values ('Fratelo', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 6);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('McDonalds', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 22.2, 7);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Outback', '2312421', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 90.5, 8);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Petiskeira', '929264832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 30.90, 9);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Madero', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 45.2, 10);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Japeska', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 52.2, 11);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Paris 6', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 42.2, 12);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Divina Padoca', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 34.2, 6);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('SOS Bebida', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 17.2, 6);





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
