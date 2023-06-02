import { Request, Response, Router } from "express";
import Controller from "../interfaces/controller.interface";
import nsideModel from "./nside.model";

export default class nsideController implements Controller {
    public router = Router();
    private nsideM = nsideModel;

    constructor() {
        this.router.get("/api/ingatlan", this.getAll);

        this.router.post("/api/ingatlan", this.create);
        this.router.delete("/api/ingatlan/:id", this.delete);
    }

    private getAll = async (req: Request, res: Response) => {
        try {
            const data = await this.nsideM.find().populate("kategoria");
            // or:
            // const data = await this.nsideM.find().populate("virtualPop");
            res.send(data);
        } catch (error) {
            res.status(400).send({ message: error.message });
        }
    };

    private create = async (req: Request, res: Response) => {
        try {
            const body = req.body;
            const createdDocument = new this.nsideM({
                ...body,
            });
            await createdDocument.save();
            res.status(201).json({ _id: createdDocument._id });
        } catch (error) {
            res.status(400).send({ message: `Hiányos adat` });
        }
    };

    private delete = async (req: Request, res: Response) => {
        try {
            const id = req.params.id;
            const successResponse = await this.nsideM.findByIdAndDelete(id);
            if (successResponse) {
                res.sendStatus(204);
            } else {
                res.status(404).send({ message: `az ingatlan nem lézeik` });
            }
        } catch (error) {
            res.status(400).send({ message: error.message });
        }
    };
}
