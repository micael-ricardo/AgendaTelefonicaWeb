# Teste para Seleção – Desenvolvimento

**Candidato:** Micael Ricardo Santana
**Data:** 09/04/2025 

##  Teste Lógico

### 1- Avalie se as afirmações são verdadeiras ou falsas. Sendo que A=10, B=2 e C=8. a) (A+B) = C ( )
- a) (A+B) = C (F)
- b) (A-C) = B (V)
- c) (A*C) < B (F)
- d) (A*B) = A (F)
- e) (A-B) = C (V)

**Tempo gasto:** 5 Minutos 

### 2- Avalie se as afirmações são verdadeiras ou falsas. X = 2, Y=3 e Z=5.

- a) (((X+Y)>=Z) and (X>Y)) (F)
- b) (((X+Y)>=Z) or (X>Y)) (V)
- c) ((Z<Y) and ((Z-Y)=X)) (F)
- d) ((X=Y) or (X<Y)) (V)
- e) (((X+Y)=Z) and (Z>Y) and ((X-Y)=Z)) (F)

**Tempo gasto:** 5 Minutos 

### 3- Mostre as saídas para as devidas entradas:
![image](https://github.com/user-attachments/assets/d359b0f8-0102-4aac-a9d2-3b31e4d6e3f9)


- Se `a = 0`: imprimir "Não há raízes reais"
- Senão: calcular `x = b / a` e imprimir
  
- Entrada 1: a=3 e b=4 = 1.33
- Entrada 2: a=0 e b=3 = Não há raízes reais
- Entrada 3: a=3 e b=9 = 3

**Tempo gasto:** 5 Minutos
  
### 4- Mostre as saídas para as devidas entradas:

![image](https://github.com/user-attachments/assets/6c86a8af-ba27-4463-a829-fc3ca269d293)

- Entrada 1: n=5 e m=3 =
m = 3  
n = 5  
r = 0  
Enquanto n != 0 faça:  
1ª iteração: r = 0 + 3 = 3   | n = 5 - 1 = 4  
2ª iteração: r = 3 + 3 = 6   | n = 4 - 1 = 3  
3ª iteração: r = 6 + 3 = 9   | n = 3 - 1 = 2  
4ª iteração: r = 9 + 3 = 12  | n = 2 - 1 = 1  
5ª iteração: r = 12 + 3 = 15 | n = 1 - 1 = 0  
Fim do enquanto  
Imprimir r → Resultado: **15**
    
- Entrada 1: n=0 e m=100001
  Inicial: r = 0  
  Como n = 0, o laço "enquanto" **não executa**  
  Resultado final: **0**
  
- Entrada 1: n=3 e m=15  
 m = 15  
 n = 3  
 r = 0  
Enquanto n ≠ 0:  
1ª iteração: r = 0 + 15 = 15   | n = 3 - 1 = 2   
2ª iteração: r = 15 + 15 = 30  | n = 2 - 1 = 1  
3ª iteração: r = 30 + 15 = 45  | n = 1 - 1 = 0  
  
Fim do enquanto  
Imprimir r → Resultado: **45**  
  
**Tempo gasto:** 15 Minutos

### 5- Escreva um algoritmo que leia 400 números e imprima o maior, o menor e a média dos números lidos.

programa {  
  funcao inicio() {  
    inteiro num[400]   
    inteiro soma = 0  
    real mediaDosValores = 0  
    inteiro maior, menor  
    
    para (inteiro i = 0; i < 400; i++) {  
      escreva("Digite o ", i+1, "º número: ")  
      leia(num[i])  
        
      se (i == 0) {  
        menor = num[i]  
        maior = num[i]  
      }  

      senao {  
        se (num[i] > maior) {  
          maior = num[i]  
        }  
        se (num[i] < menor) {  
          menor = num[i]  
        }  
      }    
    }  
    
    para(inteiro i = 0; i < 400; i++) {  
      soma += num[i]  
    }  
    
    mediaDosValores = soma / 400.0     
    
    escreva("Menor Valor: ", menor, "\n")  
    escreva("Maior Valor: ", maior, "\n")  
    escreva("Média dos Valores: ", mediaDosValores)  
  }   
}  

### Feito e testado no : https://portugol.dev/

**Tempo gasto:** 40 Minutos

### 6- Escreva um algoritmo que leia seis números e os imprima em ordemcrescente.

programa {  
  funcao inicio() {  

    inteiro num[6]  
    inteiro aux  

    para (inteiro i = 0; i < 6; i++) {  
      escreva("Digite os valor " + (i + 1) + ": ")  
      leia(num[i])  
    
      para(inteiro j = 0; j < 6; j++){  
        se(num[i] < num[j]){  
          aux = num[i]  
          num[i] = num[j]  
          num[j] = aux  
        }    
      }  
    }   
  
  
    para (inteiro i = 0; i < 6; i++){  
      escreva(num[i] , " ")  
    }    
  }  
}  
### Feito e testado no : https://portugol.dev/

**Tempo gasto:** 15 Minutos



<H1> TESTE PRÁTICO </H1>

### 1. Desenvolver uma aplicação WEB, que permita cadastrar e pesquisar contatospara uma agenda telefônica. Neste cadastro deve conter o nome da pessoa, idade, e número dos possíveis telefones que ela pode ter. Na parte de pesquisa, devepermitir pesquisar pelo nome e numero do telefone.  
### Obs.: As estruturas das tabelas estarão discriminadas no fimdo relatório. A tela de cadastro de CONTATO será composta por:
- a. Botão de inclusão para contato;
- A tela de pesquisa de CONTATO será composta por:
- b. Botão de pesquisa para os CONTATOS;
- c. Botão de alteração para o CONTATO SELECIONADO;
- d. Botão de exclusão para o CONTATO SELECIONADO;  
###   2. Precisamos também de um LOG, para nos mostrar quando foi excluido umcontato. Esse LOG será gravado em um arquivo texto. 3. Classifique o Teste que terminou de realizar. Comente o porquê de sua resposta.

### 3. Classifique o Teste que terminou de realizar. Comente o porquê de sua resposta.   
  
Médio –  O teste propôs a construção de um CRUD, algo comum e simples em termos de estrutura, porém com requisitos que exigiram atenção a detalhes e organização do código. A parte de cadastrar múltiplos telefones para um mesmo contato, por exemplo, envolveu o uso de ViewModels e manipulação dinâmica no front-end, o que trouxe uma camada extra de complexidade.  

**Tempo gasto:** 55 Horas 
  
### 📞 Agenda Telefônica Web  
   
  Este projeto é uma aplicação web ASP.NET Core MVC que permite o cadastro, pesquisa, alteração e exclusão de contatos em uma agenda telefônica, com possibilidade de múltiplos telefones por contato. Um log em arquivo texto é gerado sempre que um contato é excluído.

  🛠️ Tecnologias Utilizadas
  ASP.NET Core MVC (.NET 9)

  Entity Framework Core (com Migrations)

  MySQL

  Bootstrap (via layout padrão MVC)

  C#

🚀 Funcionalidades
✅ Cadastro de contatos com nome, idade e múltiplos telefones

✅ Pesquisa de contatos por nome e número de telefone

✅ Alteração de contatos

✅ Exclusão de contatos

✅ Log de exclusão salvo em arquivo .txt

✅ Scaffold de CRUD gerado via Entity Framework
  
💻 Como rodar o projeto localmente
1. Pré-requisitos
.NET 9 SDK

MySQL Server

Um gerenciador de banco de dados MySQL (como MySQL Workbench, DBeaver, ou HeidiSQL)


2. Configuração do Banco de Dados
Antes de executar o projeto, crie o banco de dados e configure as permissões do usuário.

Script SQL:
CREATE DATABASE AgendaTelefonicaDB;

CREATE USER 'developer'@'localhost' IDENTIFIED BY '1234567';
GRANT ALL PRIVILEGES ON AgendaTelefonicaDB.* TO 'developer'@'localhost';
FLUSH PRIVILEGES;

3. Configurar a Connection String
No arquivo appsettings.json, a string de conexão já está definida como:  
"ConnectionStrings": {  
  "AgendaTelefonicaWebContext": "Server=localhost;Port=3306;Database=AgendaTelefonicaDB;User=developer;Password=1234567;"
}  
  
Ajuste caso esteja usando outro usuário/senha.  

4. Rodar as Migrations  
Abra o terminal na raiz do projeto e execute:

Add-migration teste
update-Database

Isso criará todas as tabelas necessárias no banco de dados.


5. Executar a Aplicação
Com o banco de dados configurado, basta rodar:  

CTRL + F5  
  


