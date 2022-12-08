Create Database Jschool;
use Jschool;

create table disciplina
( 
	id INT NOT NULL AUTO_INCREMENT,
    nome varchar (30),
    professor varchar (60) NOT NULL,
    PRIMARY KEY (id)
);


INSERT INTO disciplina (nome,professor) VALUES ('UX', 'André');
INSERT INTO disciplina (nome,professor) VALUES ('Projeto Integrador', 'Frank');
INSERT INTO disciplina (nome,professor) VALUES ('Análise de Projeto', 'João');
INSERT INTO disciplina (nome,professor) VALUES ('DEV Mobile', 'André');

create table avaliacao
(
	id INT NOT NULL AUTO_INCREMENT, 
    comentario VARCHAR(100), 
    avaliacao int NOT NULL,
    idDisciplina int,
    PRIMARY KEY (id),
    FOREIGN KEY (idDisciplina) REFERENCES disciplina(id)
);