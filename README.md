# PitStopConcurrency

**PitStopConcurrency** é uma robusta e escalável API web projetada para gerenciar e otimizar estratégias de pitstop em cenários de corrida. Utilizando técnicas modernas de concorrência, incluindo programação assíncrona, paralela e reativa, a aplicação garante o manuseio eficiente de múltiplos carros de corrida e dados de telemetria em tempo real.

## 🚀 Funcionalidades

- **Arquitetura Limpa**: Separação de responsabilidades com camadas distintas de Domínio, Aplicação, Infraestrutura e Apresentação.
- **Programação Assíncrona**: Operações não bloqueantes para melhorar o desempenho e a escalabilidade.
- **Processamento Paralelo**: Manuseio simultâneo de múltiplos carros para otimizar estratégias de pitstop.
- **Programação Reativa**: Processamento de dados em tempo real e manipulação de eventos usando Reactive Extensions (Rx.NET) e SignalR para atualizações ao vivo.
- **Banco de Dados InMemory**: Configuração simplificada usando o provedor InMemory do Entity Framework Core para desenvolvimento e testes.
- **Integração com Swagger**: Documentação interativa da API e testes através do Swagger UI.

## 🛠 TODO
- **Telemetria em Tempo Real**: Atualizações ao vivo dos dados de telemetria dos carros utilizando hubs do SignalR.

## 🏗 Arquitetura

PitStopConcurrency segue os princípios da **Arquitetura Limpa**, garantindo um código manutenível e testável:

- **Camada de Domínio**: Encapsula a lógica de negócio e entidades principais.
- **Camada de Aplicação**: Lida com casos de uso, comandos, consultas e orquestra interações entre Domínio e Infraestrutura.
- **Camada de Infraestrutura**: Gerencia persistência de dados, serviços externos e implementa interfaces de repositório.
- **Camada WebAPI**: Exponha endpoints RESTful, integra o Swagger para documentação da API e gerencia comunicações em tempo real via SignalR.

## 🛠 Tecnologias Utilizadas

- **.NET 7**
- **ASP.NET Core Web API**
- **Entity Framework Core (InMemory)**
- **Swashbuckle.AspNetCore (Swagger)**
- **SignalR**
- **Reactive Extensions (Rx.NET)**
- **C# 10**

## 📦 Começando

### Pré-requisitos

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Git](https://git-scm.com/downloads)

### Instalação

1. **Clone o repositório:**

    ```bash
    git clone https://github.com/seuusuario/PitStopConcurrency.git
    cd PitStopConcurrency
    ```

2. **Navegue para o projeto WebAPI:**

    ```bash
    cd PitStopConcurrency.WebAPI
    ```

3. **Restaure as dependências:**

    ```bash
    dotnet restore
    ```

### Executando a Aplicação

1. **Execute o projeto WebAPI:**

    ```bash
    dotnet run
    ```

2. **Acesse o Swagger UI:**

    Uma vez que a aplicação estiver rodando, o Swagger UI será aberto automaticamente no seu navegador padrão em [https://localhost:5001/swagger](https://localhost:5001/swagger) ou [http://localhost:5000/swagger](http://localhost:5000/swagger), dependendo da configuração.

## 🧑‍💻 Uso

- **Gerenciar Carros e Corridas:**
  - Criar, ler, atualizar e deletar carros de corrida e corridas.
  - Agendar ou forçar pitstops para carros específicos.

- **Telemetria em Tempo Real:**
  - Receber atualizações ao vivo dos dados de telemetria dos carros através de hubs do SignalR.
  - Monitorar desgaste de pneus, níveis de combustível, temperaturas do motor e mais em tempo real.

- **Otimizar Estratégias de Pitstop:**
  - Utilizar processamento paralelo para gerenciar múltiplos cálculos de pitstop simultaneamente.
  - Reagir a mudanças de dados em tempo real com paradigmas de programação reativa.

## 📝 Documentação da API

A documentação interativa da API está disponível através do Swagger UI. Após executar a aplicação, navegue para:

- [https://localhost:5001/swagger](https://localhost:5001/swagger)
- ou [http://localhost:5000/swagger](http://localhost:5000/swagger)

## 🔧 Configuração

### appsettings.json

Configure as definições da sua aplicação em `appsettings.json` e `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "PitStopDatabase": "InMemory"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "TelemetryApi": {
    "BaseUrl": "http://localhost:5001"
  }
}
```

## 🤝 Contribuindo
Contribuições são bem-vindas! Siga os passos abaixo para contribuir com o PitStopConcurrency:

Faça um Fork do repositório

Clique no botão "Fork" no canto superior direito da página do repositório para criar uma cópia do repositório na sua conta do GitHub.

Clone o seu Fork

`git clone https://github.com/seuusuario/PitStopConcurrency.git`

`cd PitStopConcurrency`

Crie uma nova branch

`git checkout -b feature/AmazingFeature`

Faça as suas alterações

Implemente a sua funcionalidade ou correção de bug.

Faça commit das suas alterações

`git commit -m "feat: add new funcionality"`

Envie para o seu Fork

`git push origin feature/AmazingFeature`

Abra um Pull Request

Vá até o repositório original e clique no botão "Compare & pull request". 
Forneça um título descritivo e uma explicação das suas alterações.

## 🛡 Licença
Este projeto está licenciado sob a Licença MIT.

## 📫 Contato
Para qualquer dúvida ou feedback, por favor, entre em contato através do email rfulgencio3@gmail.com

Obrigado por conferir o PitStopConcurrency! 
Esperamos que ele ajude você a construir aplicações de gerenciamento de corridas eficientes e escaláveis.
