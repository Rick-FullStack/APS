# Plataforma Inteligente de Monitoramento Ambiental - Rio Tietê

Projeto desenvolvido para a disciplina de **Atividades Práticas Supervisionadas (APS)** do curso de Ciência da Computação.
**Trabalho de Atividades Práticas Supervisionadas (APS) - Ciência da Computação**

## 🎯 Tema
**Desenvolvimento de uma Plataforma Inteligente de Comunicação em Rede para Monitoramento Ambiental e Suporte à Sustentabilidade Urbana**

## 📋 Descrição do Projeto

Sistema desenvolvido para permitir que indústrias enviem dados ambientais em tempo real para o centro administrativo da Secretaria de Estado do Meio Ambiente, focado no monitoramento do Rio Tietê.

## 🎯 Objetivo
Desenvolver uma plataforma de comunicação em rede utilizando **sockets TCP/IP** (Berkeley style) para monitoramento ambiental do Rio Tietê, atendendo à Secretaria de Estado do Meio Ambiente.
O projeto utiliza sockets TCP/IP (Berkeley) conforme exigido na proposta.

## ✨ Funcionalidades Implementadas
## ✨ Funcionalidades

- **Servidor TCP** em Background Service (.NET)
- **Cliente Console** simulando indústrias (envio de dados em tempo real)
- **Dashboard Web** em Blazor Server com atualização em tempo real (SignalR)
- Envio de dados ambientais (poluição, pH, temperatura, etc.)
- Comunicação TCP Socket em tempo real
- Dashboard interativo com atualização automática (SignalR)
- Envio de dados ambientais (nível de poluição, pH, temperatura, oxigênio dissolvido)
- Envio de alertas críticos
- Envio de relatórios
- Interface responsiva com MudBlazor
- Interface moderna e responsiva

## 🛠️ Tecnologias Utilizadas

- **C# / .NET 10**
- Blazor Server
- MudBlazor
- SignalR
- System.Net.Sockets (Berkeley Sockets)
- JSON para serialização
- **Backend:** C# .NET 10
- **Frontend:** Blazor Server
- **UI:** MudBlazor
- **Comunicação em Rede:** System.Net.Sockets (TCP/IP)
- **Tempo Real:** Microsoft SignalR
- **Arquitetura:** Multi-projeto (Shared + Server + Client)

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
