# Plataforma Inteligente de Monitoramento Ambiental - Rio Tietê

Projeto desenvolvido para a disciplina de **Atividades Práticas Supervisionadas (APS)** do curso de Ciência da Computação.

## 🎯 Objetivo
Desenvolver uma plataforma de comunicação em rede utilizando **sockets TCP/IP** (Berkeley style) para monitoramento ambiental do Rio Tietê, atendendo à Secretaria de Estado do Meio Ambiente.

## ✨ Funcionalidades Implementadas

- **Servidor TCP** em Background Service (.NET)
- **Cliente Console** simulando indústrias (envio de dados em tempo real)
- **Dashboard Web** em Blazor Server com atualização em tempo real (SignalR)
- Envio de dados ambientais (poluição, pH, temperatura, etc.)
- Envio de alertas críticos
- Envio de relatórios
- Interface responsiva com MudBlazor

## 🛠️ Tecnologias Utilizadas

- **C# / .NET 10**
- Blazor Server
- MudBlazor
- SignalR
- System.Net.Sockets (Berkeley Sockets)
- JSON para serialização

## 🚀 Como Executar

### 1. Clonar o repositório
```bash
git clone https://github.com/Rick-FullStack/APS.git
cd APS