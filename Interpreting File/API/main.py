from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from API.routers import extraction

app = FastAPI(
    title="API de Extração de Dados de Análise de Solo e Foliar",
    description="Faça o upload de um laudo em PDF para extrair os dados em formato JSON estruturado.",
    version="2.0.0"
)

app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

app.include_router(extraction.router, prefix="/api", tags=["Extração de Dados"])

@app.get("/")
def read_root():
    return {"message": "Bem-vindo à API de Extração de Dados"}

#Como rodar
#uvicorn API.main:app --reload