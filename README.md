
```
# 🌊 Monitoramento Ambiental Inteligente — Rio TietêPlataforma distribuída para coleta e monitoramento de dados ambientais em tempo real, utilizando comunicação via sockets TCP/IP e atualização dinâmica de interface.---## 📌 Visão GeralSistema projetado para simular um cenário real onde indústrias enviam dados ambientais continuamente para um centro de monitoramento governamental.A aplicação processa e exibe métricas críticas como:- Nível de poluição- pH da água- Temperatura- Oxigênio dissolvidoCom suporte a:- Alertas em tempo real- Visualização centralizada- Simulação de múltiplas fontes emissoras---## ⚙️ ArquiteturaEstrutura baseada em solução multi-projeto:
```

APS/  
├── APS/ → Servidor + Dashboard (Blazor Server + TCP Server)  
├── APS.Client/ → Cliente simulador (indústria via TCP)  
└── APS.Shared/ → Modelos e contratos compartilhados

```
### Fluxo de dados
```

[Indústrias (Client)]  
↓ TCP/IP (Sockets)  
[Servidor Central (.NET)]  
↓ SignalR  
[Dashboard Web (Blazor)]

```
---## 🧠 Stack Tecnológica- **Backend:** .NET 10 (C#)- **Frontend:** Blazor Server- **UI:** MudBlazor- **Comunicação:** TCP/IP (System.Net.Sockets)- **Tempo real:** SignalR---## 🚀 Execução### Pré-requisitos- .NET SDK 10+- Ambiente de desenvolvimento compatível (Visual Studio / VS Code)---### 1. Clonar repositório```bashgit clone https://github.com/Rick-FullStack/APS.gitcd APS
```
### 1. Clonar o repositório
```
git clone https://github.com/Rick-FullStack/APS.git
```

----------

### 2. Entrar na pasta do projeto

```
cd APS
```
----------

### 3. Restaurar dependências

```
dotnet restore
```

----------

### 4. Executar o servidor (Dashboard + TCP)

```
cd APS
dotnet run
```

----------

### 5. Executar cliente (simulação de indústria)

Em outro terminal:

```
cd APS.Clientdotnet run
```

----------

### 6. Acessar aplicação

Abra no navegador:

```
https://localhost:7xxx
```

(A porta exata será exibida no terminal)

----------

## 📡 Funcionalidades

-   Comunicação TCP persistente entre cliente e servidor
-   Atualização em tempo real via SignalR
-   Dashboard com visualização contínua dos dados
-   Geração de alertas para valores críticos
-   Simulação de múltiplos emissores de dados

----------

## ⚠️ Limitações

-   Não utiliza autenticação/autorização
-   Dados não persistidos (memória volátil)
-   Ambiente de simulação (não conectado a sensores reais)

----------

## 🎓 Contexto Acadêmico

Projeto desenvolvido como Atividade Prática Supervisionada (APS) para o curso de Ciência da Computação.

Objetivo: demonstrar aplicação prática de:

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

> Recomenda-se adicionar:
> 
> -   Screenshot do dashboard
> -   Output do cliente
> -   Fluxo de dados (diagrama)

----------

## 📄 Licença

Uso acadêmico.
