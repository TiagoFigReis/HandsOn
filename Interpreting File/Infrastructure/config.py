import os
from dotenv import load_dotenv

load_dotenv()

class Settings:
    GOOGLE_API_KEY: str = os.getenv("GOOGLE_API_KEY")

    if not GOOGLE_API_KEY:
        raise ValueError("A variável de ambiente GOOGLE_API_KEY não foi definida.")

settings = Settings()