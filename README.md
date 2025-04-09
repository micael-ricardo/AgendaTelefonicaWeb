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




  


