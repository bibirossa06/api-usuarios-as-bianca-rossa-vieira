# API de Gerenciamento de Usuários

## Descrição
Projeto desenvolvido para a Avaliação Semestral de Desenvolvimento Backend. É uma API REST para o gerenciamento de usuários (CRUD), estruturada seguindo os princípios da **Clean Architecture** para garantir escalabilidade e fácil manutenção.

## Tecnologias do Projeto
- .NET 8.0 (Minimal APIs)
- Entity Framework Core
- SQLite (Banco de dados)
- FluentValidation (Validação de dados)
- Swagger (Documentação interativa)

## Padrões e Justificativas de Projeto
Para atender aos requisitos acadêmicos e técnicos, foram adotados:
- **Clean Architecture:** Estrutura organizada em camadas Domain, Application, Infrastructure e APIUsuarios.
- **Repository Pattern:** Abstração da camada de acesso a dados.
- **Service Pattern:** Centralização da lógica de negócio.
- **DTO Pattern:** Uso de objetos para transporte e proteção dos dados.
- **Exclusão Lógica (Soft Delete):** A remoção de usuários apenas muda o campo `Ativo` para `false`, mantendo os registros no banco para fins de auditoria.

## Rotas da API

| Método | Rota | Descrição |
|---|---|---|
| GET | /usuarios | Lista todos os usuários ativos. |
| GET | /usuarios/{id} | Busca um usuário ativo pelo ID. |
| POST | /usuarios | Cadastra um novo usuário. |
| PUT | /usuarios/{id} | Atualiza os dados de um usuário. |
| DELETE | /usuarios/{id} | Realiza o Soft Delete (muda para inativo). |

## Como Iniciar o Projeto
### Pré-requisitos
- .NET SDK 8.0 instalado.

### Passo a Passo
1. Clone este repositório.
2. Na pasta raiz, aplique as migrações:
   ```bash
   dotnet ef database update

 ## Estrutura do Projeto
Explicação das pastas e arquivos: O projeto segue a **Clean Architecture**, separando as responsabilidades em: **Domain** (entidade `Usuario`), **Application** (lógica de negócio, DTOs e Validadores), **Infrastructure** (Repositórios e DbContext) e **APIUsuarios** (ponto de entrada).

## Autor
Seu nome completo: **Bianca Rossa Vieira**
Curso: Análise e Desenvolvimento de Sistemas

## Vídeo Demonstrativo
https://drive.google.com/file/d/1DkKK2DRqJ3IQyk9SNZhX_A4J_r3R-doW/view?usp=drivesdk