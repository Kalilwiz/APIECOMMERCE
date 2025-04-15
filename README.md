# Criar uma interface
- Criar uma interface dentro da pasta interfaces do tipo interface
- Criar os metodos CRUD
- Cadastrar - Listar - Atualizar - Deletar

# Criar um Repository

- Criar um Repository Dentro da pasta repository com o arquivo do tipo Classe
- Herdar a interface do repository
- Implementar a interface
- Injetar o contexto usando Private readonly
- Implementar todos os metodos

# Configurar Injeção de dependencia

- Configurar a injeção de dependencia do contexto usando ADDScoped
- Configurar a injeção de dependencia dos controllers usando ADDTransient


# Criar controllers

- Criar um controller dentro da pasta Controllers do tipo API controller - vazio
- Chamar o metodo Controlador CTOR
- Criar um objeto do tipo da Interface
- injetar a interface dentro do seu controlador para criar uma injeção de dependencia
- Criar o metodo httpget usando [httpget] e um metodo do tipo IActionResult
- Criar o metodo httpPost usando [httpPost] e um metodo do tipo IActionResult
