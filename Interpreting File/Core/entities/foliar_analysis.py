from pydantic import BaseModel
from typing import List, Optional

class FoliarSample(BaseModel):
    id_amostra: Optional[str] = None
    identificacao_talhao: Optional[str] = None
    cultura: Optional[str] = None
    nitrogenio_n: Optional[float] = None
    fosforo_p: Optional[float] = None
    potassio_k: Optional[float] = None
    calcio_ca: Optional[float] = None
    magnesio_mg: Optional[float] = None
    enxofre_s: Optional[float] = None
    boro_b: Optional[float] = None
    cobre_cu: Optional[float] = None
    ferro_fe: Optional[float] = None
    manganes_mn: Optional[float] = None
    zinco_zn: Optional[float] = None

class FoliarAnalysisReport(BaseModel):
    amostras_foliar: List[FoliarSample]