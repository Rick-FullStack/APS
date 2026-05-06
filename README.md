```markdown
# Plataforma Inteligente de Monitoramento Ambiental - Rio Tietê

**Trabalho de Atividades Práticas Supervisionadas (APS) - Ciência da Computação**

## 🎯 Tema
**Desenvolvimento de uma Plataforma Inteligente de Comunicação em Rede para Monitoramento Ambiental e Suporte à Sustentabilidade Urbana**

## 📋 Descrição do Projeto

Sistema desenvolvido para permitir que indústrias enviem dados ambientais em tempo real para o centro administrativo da Secretaria de Estado do Meio Ambiente, focado no monitoramento do Rio Tietê.

O projeto utiliza sockets TCP/IP (Berkeley) conforme exigido na proposta.

## ✨ Funcionalidades

- Comunicação TCP Socket em tempo real
- Dashboard interativo com atualização automática (SignalR)
- Envio de dados ambientais (nível de poluição, pH, temperatura, oxigênio dissolvido)
- Envio de alertas críticos
- Envio de relatórios
- Interface moderna e responsiva

## 🛠️ Tecnologias Utilizadas

- **Backend:** C# .NET 10
- **Frontend:** Blazor Server
- **UI:** MudBlazor
- **Comunicação em Rede:** System.Net.Sockets (TCP/IP)
- **Tempo Real:** Microsoft SignalR
- **Arquitetura:** Multi-projeto (Shared + Server + Client)

## 🚀 Como Executar

### 1. Clonar / Baixar o projeto
```bash
git clone https://github.com/Rick-FullStack/APS.git
cd APS
```

### 2. Restaurar pacotes
```bash
dotnet restore
```

### 3. Rodar o Servidor (Dashboard)
```bash
cd APS
dotnet run
```

### 4. Rodar o Cliente (Indústria) - Em outro terminal
```bash
cd APS.Client
dotnet run
```

Acesse o dashboard no link exibido no terminal (geralmente `https://localhost:7xxx`)

## 👥 Integrantes

- César Henrique
- André Camargo
- Luciano Cardoso

## 📁 Estrutura de Pastas

- **APS/** → Aplicação principal (Blazor + Servidor TCP)
- **APS.Client/** → Cliente console para simulação das indústrias
- **APS.Shared/** → Modelos compartilhados entre os projetos

## 📸 Screenshots

*(Adicionar prints do dashboard e do cliente)*

---

**Pronto!**  

Depois de criar o arquivo, faça o commit:

```bash
git add README.md
git commit -m "docs: adiciona README.md completo e profissional"
```
