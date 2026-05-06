
# 🌊 Plataforma Inteligente de Monitoramento Ambiental — Rio Tietê

Projeto desenvolvido para a disciplina de Atividades Práticas Supervisionadas (APS) do curso de Ciência da Computação.

----------

## 🎯 Tema

Desenvolvimento de uma plataforma de comunicação em rede para monitoramento ambiental e suporte à sustentabilidade urbana.

----------

## 📋 Descrição

Sistema que permite o envio de dados ambientais em tempo real por indústrias para um centro de monitoramento governamental, com foco no Rio Tietê.

----------

## 🎯 Objetivo

Implementar uma solução baseada em sockets TCP/IP (Berkeley) para comunicação em rede, com visualização em tempo real e suporte a alertas ambientais.

----------

## ⚙️ Arquitetura

```
APS (solution)
├── APS               → Aplicação principal (Servidor TCP + Blazor Dashboard)
├── APS.Client        → Cliente console (simulação das indústrias)
└── APS.Shared        → Biblioteca de modelos/DTOs compartilhados
```

----------

## ✨ Funcionalidades

-   Servidor TCP utilizando Background Service (.NET)
-   Cliente console simulando múltiplas indústrias
-   Dashboard web com atualização em tempo real (SignalR)
-   Envio de dados ambientais:
    -   Poluição
    -   pH
    -   Temperatura
    -   Oxigênio dissolvido
-   Geração de alertas críticos
-   Interface responsiva com MudBlazor

----------

## 🧠 Tecnologias

-   C# / .NET 10
-   Blazor Server
-   MudBlazor
-   SignalR
-   System.Net.Sockets (TCP/IP)
-   JSON (serialização)

----------

## 🚀 Execução

### 1. Clonar repositório

```
git clone https://github.com/Rick-FullStack/APS.git
```

### 2. Entrar na pasta

```
cd APS
```

### 3. Restaurar dependências

```
dotnet restore
```

### 4. Executar servidor

```
cd APSdotnet run
```

### 5. Executar cliente

Em outro terminal:

```
cd APS/APS.Clientdotnet run
```

### 6. Acessar

```
https://localhost:7xxx
```

----------

## 📡 Funcionalidades do Sistema

-   Comunicação TCP persistente
-   Atualização em tempo real com SignalR
-   Dashboard com dados contínuos
-   Sistema de alertas
-   Suporte a múltiplos clientes simultâneos

----------

## ⚠️ Limitações

-   Sem autenticação/autorização
-   Sem persistência de dados
-   Ambiente de simulação

----------

## 🎓 Contexto Acadêmico

Projeto voltado à aplicação prática de:

-   Comunicação em rede com sockets
-   Sistemas distribuídos
-   Atualização em tempo real

----------

## 👥 Autores

-   César Henrique
-   André Camargo
-   Luciano Cardoso

----------

## 📷 Demonstração

Adicionar:

-   Screenshot do dashboard
-   Output do cliente
-   Diagrama de fluxo

----------

## 📄 Licença

Uso acadêmico.
