create database bdProjetoCRUD;
use bdProjetoCRUD;
 
CREATE TABLE Funcionario (
    id_func INT PRIMARY KEY AUTO_INCREMENT,
    nome_func VARCHAR(100),
    cpf_func VARCHAR(14)
);

CREATE TABLE Caixa (
    id_cai INT PRIMARY KEY AUTO_INCREMENT,
    saldo_inicial_cai DOUBLE,
    total_entrada_cai DOUBLE,
    total_saida_cai DOUBLE,
    status_cai VARCHAR(20),
    id_func_fk INT NOT NULL,
    FOREIGN KEY (id_func_fk)
        REFERENCES funcionario (id_func) ON DELETE RESTRICT
);

CREATE TABLE Despesa (
    id_des INT PRIMARY KEY AUTO_INCREMENT,
    valor_des DOUBLE,
    data_pag_des DATE,
    data_venc_des DATE,
    status_des VARCHAR(20),
    id_cai_fk INT NOT NULL,
    FOREIGN KEY (id_cai_fk)
        REFERENCES caixa (id_cai)
);

insert into funcionario values (null, "Eloizy Campi Reis", "222");

insert into caixa values (null, 10, 504, 540, "aaa", 1);

select * from caixa;
select * from despesa;

SELECT * FROM Caixa INNER JOIN Funcionario as f ON id_func_fk = id_func ORDER BY id_func;