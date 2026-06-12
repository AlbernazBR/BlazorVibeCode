# Catálogo Técnico de Motocicletas 2026 - CLAUDE.md

## Visão Geral do Projeto
Uma aplicação web de pequeno porte construída para aprender Blazor Server, com foco em persistência de dados e arquitetura backend limpa. O sistema cataloga famílias e especificações técnicas de motocicletas estilo custom/cruiser da linha de 2026.

- **Stack Tecnológica:** .NET 10 (LTS) / Blazor Server, Entity Framework Core, SQLite, MudBlazor.
- **Arquitetura:** Separação estrita de conceitos com aplicação rigorosa do SOLID e inversão de dependência via interfaces.

---

## Comandos Principais

### Desenvolvimento e Execução
- **Compilar o projeto:** `dotnet build`
- **Executar a aplicação:** `dotnet run`
- **Executar com Hot Reload (Recomendado para UI):** `dotnet watch`
- **Publicar/Gerar release:** `dotnet publish -c Release`

### Gerenciamento de Banco de Dados (EF Core)
- **Criar uma nova migration:** `dotnet ef migrations add <NomeDaMigration>`
- **Atualizar o banco de dados:** `dotnet ef database update`
- **Apagar o banco de dados:** `dotnet ef database drop`

---

## Diretrizes de Código

### Idioma e Convenções
- **Idioma:** O código-fonte, nomes de variáveis, métodos, classes, interfaces e comentários devem ser escritos estritamente em **Português**.
- **Organização de Constantes:** Agrupar as constantes de configuração do sistema (ex: categorias de motores, tipos de chassi) de forma limpa em classes estáticas especializadas ou modelos de configuração dedicados.

### Conformidade Rigorosa com o SOLID
O Claude Code deve projetar e refatorar o código seguindo os cinco princípios do SOLID:

1. **S - Princípio da Responsabilidade Única (SRP):**
   - Arquivos `.razor` lidam **apenas** com renderização de UI, captura de eventos e exibição de estado.
   - Toda lógica de negócio, validação complexa e persistência deve ser isolada em serviços específicos.

2. **O - Princípio Aberto/Fechado (OCP):**
   - Projetar comportamentos extensíveis via polimorfismo ou herança. Regras técnicas que variam por categoria de moto não devem gerar "if/else" infinitos em classes centrais.

3. **L - Princípio da Substituição de Liskov (LSP):**
   - Classes derivadas devem poder substituir suas classes base ou interfaces sem quebrar o comportamento do sistema. Não lançar `NotImplementedException`.

4. **I - Princípio da Segregação de Interfaces (ISP):**
   - Criar interfaces pequenas, coesas e focadas. Componentes de UI devem enxergar apenas os métodos que realmente precisam consumir.

5. **D - Princípio da Inversão de Dependência (DIP):**
   - Componentes Blazor e outras classes **nunca** devem depender de serviços concretos; devem depender sempre de **Interfaces** (ex: injetar `IMotoService` em vez de `MotoService`).
   - Configurar o mapeamento das interfaces no contêiner de IoC nativo do .NET (`Program.cs`).

### Backend (C# & EF Core)
- Utilizar programação assíncrona (`async/await`) para todas as operações de I/O.
- Forçar o uso de `AsNoTracking()` em consultas de leitura no Entity Framework.
- Inicializar propriedades do tipo texto como `string.Empty` por padrão.

### Frontend (Blazor Server)
- Injetar dependências na UI usando a diretiva `@inject INTERFACE_AQUI`.
- Utilizar os componentes de input nativos do Blazor (`<EditForm>`, `<InputText>`, etc.) com validação via `DataAnnotationsValidator`.
- Aproveitar os recursos do .NET 10 para gerenciamento de estado resiliente e otimização de renderização.