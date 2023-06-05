# Documentação da Aplicação CLI para Gerenciamento de Churrasco da `Trinca`

## Descrição
Esta aplicação CLI (Interface de Linha de Comando) foi desenvolvida para gerenciar churrascos. Ela permite criar eventos de churrasco, listar os churrascos existentes e adicionar participantes aos eventos, incluindo suas contribuições, bebidas e itens adicionais que irão trazer.

## Comandos Disponíveis
### Listar Churrascos
Comando:

```powershell
dotnet run trinca barbecue list
```
Descrição:

Este comando lista todos os churrascos presentes na base de dados.

### Criar um Evento de Churrasco
Comando:

```powershell
dotnet run trinca barbecue create --description "Primeiro Churras da galera!!!!" --begin "12/01/2024 13:00:00" --end "12/01/2024 17:00:00" --remark "Traga seu amigo!!!!!!"
```
Descrição:
Este comando cria um novo evento de churrasco com os seguintes detalhes:

- Descrição: Uma descrição opcional do evento.
- Data e hora de início: A data e hora de início do churrasco no formato "dd/mm/yyyy hh:mm:ss".
- Data e hora de término: A data e hora de término do churrasco no formato "dd/mm/yyyy hh:mm:ss".
- Observações: Observações adicionais sobre o evento.

### Adicionar um Participante ao Evento de Churrasco
Comando:

```powershell
dotnet run trinca barbecue participant create --bind "1f54424b-d028-4d98-8b5c-c7e6e47b1ba7" --name "Thamirys Melo" --contribution 245,95 --bring-drink false --username thams --add-items "Item 001;Item 002;Item 003;brinds para o pessoal"
```

Descrição:
Este comando adiciona um novo participante ao evento de churrasco com os seguintes detalhes:

- `--bind`: O identificador único do evento de churrasco ao qual o participante será adicionado.
- `--name`: O nome do participante.
- `--contribution`: O valor da contribuição do participante para o churrasco.
- `--bring-drink`: Indica se o participante irá trazer uma bebida (true/false).
- `--username`: O nome de usuário do participante.
- `--add-items`: Itens adicionais que o participante irá trazer separados por ponto e vírgula.

## Fluxo de Uso Comum

```powershell
dotnet run trinca barbecue create --description "Primeiro Churras da galera!!!!" --begin "12/01/2024 13:00:00" --end "12/01/2024 17:00:00" --remark "Traga seu amigo!!!!!!"
```


```powershell
dotnet run trinca barbecue participant create --bind "1f54424b-d028-4d98-8b5c-c7e6e47b1ba7" --name "Thamirys Melo" --contribution 245,95 --bring-drink false --username thams --add-items "Item 001;Item 002;Item 003;brinds para o pessoal"
```

```powershell
dotnet run trinca barbecue list
```

Notas Adicionais

> *Certifique-se de ter o ambiente de desenvolvimento .NET instalado.
Verifique se os parâmetros fornecidos nos comandos estão corretos e no formato adequado.
Divirta-se gerenciando seus churrascos com a aplicação CLI da `Trinca`!*