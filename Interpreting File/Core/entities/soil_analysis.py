from pydantic import BaseModel
from typing import List, Optional

class SoilSample(BaseModel):
    id_amostra: Optional[str] = None
    identificacao_talhao: Optional[str] = None
    cultura: Optional[str] = None
    fosforo_p: Optional[float] = None
    potassio_k: Optional[float] = None
    calcio_ca: Optional[float] = None
    magnesio_mg: Optional[float] = None
    Aluminio_al: Optional[float] = None
    ph_h2o: Optional[float] = None
    acidez_potencial_h_al_cmolc_dm3: Optional[float] = None
    soma_bases_sb_cmolc_dm3: Optional[float] = None
    ctc_ph7_T_cmolc_dm3: Optional[float] = None
    saturacao_bases_v_percent: Optional[float] = None
    materia_organica_mo_percent: Optional[float] = None
    boro_b: Optional[float] = None
    cobre_cu: Optional[float] = None
    ferro_fe: Optional[float] = None
    manganes_mn: Optional[float] = None
    zinco_zn: Optional[float] = None
    enxofre_s: Optional[float] = None

class SoilAnalysisReport(BaseModel):
    amostras_solo: List[SoilSample]